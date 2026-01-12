using QazaqGeoReports.Domain.Common;
using System.Globalization;

namespace QazaqGeoReports.Application.DTOs.CarDtos;

public class CarQueryDto
{
    public string? Query { get; set; }
    public CarStatus? Status { get; set; }
    public SortKey Sort { get; set; } = SortKey.UpdatedDesc;

}
public enum SortKey
{
    UpdatedDesc,    
    BrandAsc,       
    YearDesc,      
    MileageDesc    
}