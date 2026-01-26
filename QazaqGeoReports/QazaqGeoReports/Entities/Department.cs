namespace QazaqGeoReports.Domain.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; } = default!;
    public int? ParentId { get; set; }
    public Department? Parent { get; set; }
    public ICollection<Department> Children { get; set; } = new List<Department>();
     
}