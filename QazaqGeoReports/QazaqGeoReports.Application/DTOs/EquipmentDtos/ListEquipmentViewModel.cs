using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Application.DTOs.EquipmentDtos;

public class ListEquipmentViewModel
{
    public string? SerialNumber { get; set; }
    public string? Name { get; set; }
    public int Count { get; set; }
    public string? Status { get; set; } = EquipmentStatus.Available.ToString();
}
