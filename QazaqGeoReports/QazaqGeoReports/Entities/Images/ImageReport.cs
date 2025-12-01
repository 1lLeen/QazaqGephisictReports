namespace QazaqGeoReports.Domain.Entities.Images;

public class ImageReport : BaseImage
{ 
    public int ReportId { get; set; }
    public Report Report { get; set; }
}
