using QazaqGeoReports.Application.DTOs.CarDtos;
using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.MissionDtos.MissionDriverAssignment;

public class BaseMissionDriverAssignmentDto : IBase
{
    public int MissionId { get; set; }
    public BaseMissionDto Mission { get; set; } = default!;

    public string DriverId { get; set; } = default!;
    public BaseUserDto Driver { get; set; } = default!;

    public int CarId { get; set; }
    public BaseCarDto Car { get; set; } = default!;
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
