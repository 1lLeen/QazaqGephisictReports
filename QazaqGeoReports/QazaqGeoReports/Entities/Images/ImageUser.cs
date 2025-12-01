namespace QazaqGeoReports.Domain.Entities.Images;

public class ImageUser : BaseImage
{
    public string UserId { get; set; }
    public User User { get; set; }
}
