using QazaqGeoReports.Application.DTOs.Common;
using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Domain.Entities;
using System.Linq.Expressions;

namespace QazaqGeoReports.Application.Interfaces.Services;
public interface IUserService
{
    Task<List<UserViewModel>> GetUsersWithStatsAsync(); 
    Task<BaseUserDto>? GetAsync(Expression<Func<User, bool>> predicate);
    Task<List<BaseUserDto>> GetAllAsync(); 
    Task<BaseUserDto> GetUserByIdAsync(string id); 
    Task<BaseUserDto> CreateAsync(CreateUserDto entity);
    Task<BaseUserDto> UpdateAsync(UpdateUserDto entity);
    Task<BaseUserDto> DeleteAsync(string id);

}
