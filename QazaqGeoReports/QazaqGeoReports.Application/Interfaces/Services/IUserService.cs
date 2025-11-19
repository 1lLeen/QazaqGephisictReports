using QazaqGeoReports.Application.DTOs.Common;
using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Domain.Entities;
using System.Linq.Expressions;

namespace QazaqGeoReports.Application.Interfaces.Services;
public interface IUserService
{
    Task<ResultDto<BaseUserDto>> GetAsync(Expression<Func<User, bool>> predicate);
    Task<ResultDto<List<BaseUserDto>>> GetAllAsync(); 
    Task<ResultDto<BaseUserDto>> GetUserByIdAsync(string id); 
    Task<ResultDto<BaseUserDto>> CreateAsync(User entity);
    Task<ResultDto<BaseUserDto>> UpdateAsync(User entity);
    Task<ResultDto<BaseUserDto>> DeleteAsync(string id);

}
