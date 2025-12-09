using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.DTOs.ImageDtos.ImageUserDtos;

public class BaseImageUserDto : IImageBase
{
    public int Id { get; set; }
    public byte[] Data { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}