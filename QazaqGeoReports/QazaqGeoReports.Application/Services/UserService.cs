using AutoMapper;
using QazaqGeoReports.Application.DTOs.Common;
using QazaqGeoReports.Application.DTOs.Helpers;
using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Application.Interfaces.Services;
using QazaqGeoReports.Domain.Entities;
using System.Linq.Expressions;

namespace QazaqGeoReports.Application.Services;
public class UserService : IUserService

{
    protected readonly IUserRepository _repository;
    protected IMapper mapper;
    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        this.mapper = mapper;
    }
    public virtual async Task<ResultDto<List<BaseUserDto>>> GetAllAsync() 
    {
        var res = await _repository.GetAllAsync();
        return ResultBuilder.BuildList<BaseUserDto, User>(res, mapper);
    }
      
    public virtual async Task<ResultDto<BaseUserDto>?> GetAsync(Expression<Func<User, bool>> predicate)
    {
        var res = mapper.Map<BaseUserDto>(await _repository.GetAsync(predicate));
        if (res is null)
        {
            return new ResultDto<BaseUserDto>
            {
                Success = false,
                Error = "DTO entity is null"
            };
        }
        return new ResultDto<BaseUserDto>
        {
            Success = true,
            Data = mapper.Map<BaseUserDto>(res)
        };

    }
    public virtual async Task<ResultDto<BaseUserDto>> GetUserByIdAsync(string id) 
    {
        var res = await _repository.GetUserByIdAsync(id);
        return ResultBuilder.Build<BaseUserDto, User>(res, mapper);
    }
    public virtual async Task<ResultDto<BaseUserDto>> CreateAsync(User entity) 
    {
        var res = await _repository.CreateAsync(entity);
        return ResultBuilder.Build<BaseUserDto, User>(res, mapper);
    }
    public virtual async Task<ResultDto<BaseUserDto>> UpdateAsync(User entity) 
    {
        var res = await _repository.UpdateAsync(entity);
        return ResultBuilder.Build<BaseUserDto, User>(res, mapper);

    }
    public virtual async Task<ResultDto<BaseUserDto>> DeleteAsync(string id) 
    {
        var res = await _repository.DeleteAsync(id);
        return ResultBuilder.Build<BaseUserDto, User>(res, mapper);
    } 
}
