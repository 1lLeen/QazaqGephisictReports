using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.DepartmentDtos;

public class CreateDepartmentDto : BaseDepartmentDto, ICreate
{
    public DateTime CreatedTime { get; set; }
}
