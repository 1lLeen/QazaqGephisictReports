using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.DTOs.DepartmentDtos;

public class BaseDepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int? ParentId { get; set; }
    public BaseDepartmentDto? Parent { get; set; }
    public ICollection<Department> Children { get; set; } = new List<Department>();
}
