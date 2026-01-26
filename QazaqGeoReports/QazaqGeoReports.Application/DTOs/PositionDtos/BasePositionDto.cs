using QazaqGeoReports.Application.Interfaces.Dtos;

namespace QazaqGeoReports.Application.DTOs.PositionDtos;

public class BasePositionDto : IBase
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int? Grade { get; set; }
    public string? Qualifier { get; set; }

    public ICollection<PositionRole> DefaultRoles { get; set; } = new List<PositionRole>();
}
