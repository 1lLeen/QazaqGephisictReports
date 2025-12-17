namespace QazaqGeoReports.Domain.Entities.Images;

public class ImageCar : BaseImage
{
    public int CarId { get; set; }
    public Car? Car { get; set; }
}
