using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.ImageDtos.ImageCarDto;

public class BaseImageCarDto : IImageBase
{
    public byte[] Data { get; set; }
}
