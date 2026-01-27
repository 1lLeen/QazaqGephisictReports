using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.DTOs.PositionDtos;

public class BasePositionDto : IBase
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int? Grade { get; set; }
    public string? Qualifier { get; set; }

    public ICollection<PositionRole> DefaultRoles { get; set; } = new List<PositionRole>();
}
