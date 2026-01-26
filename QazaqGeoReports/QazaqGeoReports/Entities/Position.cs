using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Domain.Entities;

public class Position : BaseEntity
{
    public string Name { get; set; } = default!;
    public int? Grade { get; set; }
    public string? Qualifier { get; set; }  

    public ICollection<PositionRole> DefaultRoles { get; set; } = new List<PositionRole>();

}
