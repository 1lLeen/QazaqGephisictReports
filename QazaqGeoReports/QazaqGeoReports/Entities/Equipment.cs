using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Domain.Entities;
public class Equipment : BaseEntity
{
    public string? SerialNumber { get; set; }
    public string? Name { get; set; }
    public int Count { get; set; }
    public string? Description { get; set; }
    public List<ImageEquipment> Images { get; set; } = new();
    public string? Status { get; set; } = EquipmentStatus.Available.ToString();
}
