namespace QazaqGeoReports.Domain.Entities.Images;
public class ImageEquipment : BaseImage
{
    public int EquipemntId { get; set; }
    public Equipment Equipment { get; set; }
}
