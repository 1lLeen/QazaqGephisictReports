using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QazaqGeoReports.Application.DTOs.UserDtos.AuthDtos;
using QazaqGeoReports.Application.Interfaces.Services;
using QazaqGeoReports.Domain.Entities.Users;

public sealed class AuthService : IAuthService
{
    private readonly IMapper _mapper;
    private readonly IRoleService _roleService;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager; 

    public AuthService(
        IMapper mapper,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IRoleService roleSerivce)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleService = roleSerivce;
    }

    public async Task<IdentityResult> RegistrationAsync(RegisterDto dto)
    {
        var user = _mapper.Map<User>(dto);
        var role = await _roleService.GetRoleByNameAsync(dto.Role);
   
        user.UserName = dto.Email;
        user.NormalizedUserName = dto.Email.Normalize();
        user.NormalizedEmail = dto.Email.Normalize();

        user.PhoneNumberConfirmed = true;
        user.EmailConfirmed = true;
        user.IsActive = true; 

        var result = await _userManager.CreateAsync(user, dto.Password);
        await _userManager.AddToRoleAsync(user, role.Name);

        if (!result.Succeeded)
            return result;

        if (!string.IsNullOrWhiteSpace(dto.Role))
            await _userManager.AddToRoleAsync(user, role.Name);

        await _signInManager.SignInAsync(user, isPersistent: false);

        await _userManager.UpdateAsync(user); 
        return IdentityResult.Success;
    }

    public async Task<SignInResult> LoginAsync(LoginDto dto)
    {
        var user = _userManager.Users.FirstOrDefault(x => x.Email == dto.Email);
        if (user is null)
            return SignInResult.Failed;

        var check = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        if (!check.Succeeded)
            return SignInResult.Failed;
        
        user.IsActive = true;

        await _userManager.UpdateAsync(user);
        return await _signInManager.PasswordSignInAsync(user,dto.Password, true, false);
    }

    public async Task LogoutAsync(User user)
    {
        if (user is not null)
        {
            user.IsActive = false;
            await _userManager.UpdateAsync(user); 
        }

        await _signInManager.SignOutAsync();
    }
}
