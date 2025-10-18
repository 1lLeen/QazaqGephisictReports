using QazaqGeoReports.Domain.Common;

namespace QazaqGeoReports.Domain.Entities;
public class Image : BaseEntity
{
    public byte[] Data { get; set; }
    public int UserId { get; set; }
} 
