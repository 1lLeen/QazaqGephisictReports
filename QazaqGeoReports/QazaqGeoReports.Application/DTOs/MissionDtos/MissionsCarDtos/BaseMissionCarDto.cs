using QazaqGeoReports.Application.DTOs.CarDtos;
using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.MissionDtos.MissionsCarDtos;

public class BaseMissionCarDto : IBase
{
    public int Id { get; set; }

    public int MissionId { get; set; }
    public BaseMissionDto Mission { get; set; } = default!;

    public int CarId { get; set; }
    public BaseCarDto Car { get; set; } = default!;
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
