using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Application.Interfaces.Services;
using QazaqGeoReports.Domain.Entities; 
using System.Linq.Expressions;

namespace QazaqGeoReports.Application.Services;
public class UserService : IUserService

{
    protected readonly IUserRepository _repository;
    protected readonly IReportService _reportService;
    protected readonly UserManager<User> _userManager;
    protected IMapper mapper;
    public UserService(IUserRepository repository, IReportService reportService, IMapper mapper, UserManager<User> manager)
    {
        _repository = repository;
        _reportService = reportService;
        _userManager = manager;
        this.mapper = mapper;
    }
    public virtual async Task<List<BaseUserDto>> GetAllAsync() 
    {
        var res = await _repository.GetAllAsync();
        return mapper.Map<List<BaseUserDto>>(res);
    }
      
    public virtual async Task<BaseUserDto>? GetAsync(Expression<Func<User, bool>> predicate)
    {
        var res = mapper.Map<BaseUserDto>(await _repository.GetAsync(predicate));
        if (res is null)
        {
            return null;
        }
        return res;
    }
    public virtual async Task<string> GetRoleByUserIdAsync(string userId)
    {
        return await _repository.GetRoleByUserIdAsync(userId);
    }
    public virtual async Task<BaseUserDto> GetUserByIdAsync(string id) 
    {
        var res = await _repository.GetUserByIdAsync(id);
        return mapper.Map<BaseUserDto>(res);
    }
    public virtual async Task<BaseUserDto> CreateAsync(CreateUserDto entity) 
    {
        var res = await _repository.CreateAsync(mapper.Map<User>(entity));
        return mapper.Map<BaseUserDto>(res);
    }
    public virtual async Task<BaseUserDto> UpdateAsync(UpdateUserDto entity) 
    {
        var res = await _repository.UpdateAsync(mapper.Map<User>(entity));
        return mapper.Map<BaseUserDto>(res);

    }
    public virtual async Task<BaseUserDto> DeleteAsync(string id) 
    {
        var res = await _repository.DeleteAsync(id);
        return mapper.Map<BaseUserDto>(res);
    }
     
    public async Task<List<UserViewModel>> GetUsersWithStatsAsync()
    {
        List<UserViewModel> userViews = new List<UserViewModel>();
        foreach(var item in await _repository.GetAllAsync())
        {
            var reports = await _reportService.GetReportsByUserAsync(item.Id);
            var roles = await _userManager.GetRolesAsync(item);

            userViews.Add(new UserViewModel
            {
                User = mapper.Map<BaseUserDto>(item),
                UserName = item.UserName,
                Role = roles.FirstOrDefault(),
                Reports = reports, 
            });
        }
        return mapper.Map<List<UserViewModel>>(userViews);
    }
}
