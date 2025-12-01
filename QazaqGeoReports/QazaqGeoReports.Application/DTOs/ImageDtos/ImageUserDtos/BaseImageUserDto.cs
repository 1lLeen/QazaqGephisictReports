using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.DTOs.ImageDtos;

public class BaseImageUserDto : IBase
{
    public int Id { get; set; }
    public byte[] Data { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}