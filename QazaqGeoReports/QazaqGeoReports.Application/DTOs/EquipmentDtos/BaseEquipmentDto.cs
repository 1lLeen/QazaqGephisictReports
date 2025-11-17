namespace QazaqGeoReports.Application.DTOs.EquipmentDtos;

public class BaseEquipmentDto
{
    public int Id { get; set; }
    public string? SerialNumber { get; set; }
    public string? Name { get; set; }
    public int Count { get; set; }
    public string? Status { get; set; } = EquipmentStatus.Available.ToString();
}
