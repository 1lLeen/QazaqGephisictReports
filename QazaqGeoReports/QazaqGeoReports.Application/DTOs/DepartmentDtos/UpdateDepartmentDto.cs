using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.DepartmentDtos;

public class UpdateDepartmentDto : BaseDepartmentDto, IUpdate
{
    public DateTime UpdatedTime { get; set; }
}
