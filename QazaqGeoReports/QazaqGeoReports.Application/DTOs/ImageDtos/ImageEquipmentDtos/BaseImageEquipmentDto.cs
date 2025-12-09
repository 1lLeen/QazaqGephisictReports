using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.DTOs.ImageDtos.ImageEquiomentDtos;

public class BaseImageEquipmentDto : IImageBase
{
    public int Id { get; set; }
    public byte[] Data { get; set; }
    public int EquipmentId{ get; set; }
    public Equipment Equipment { get; set; }
}