using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Interfaces.Repositories;
using QazaqGeoReports.Domain.Interfaces.Services;

namespace QazaqGeoReports.Application.Services;
public class ImageService : AbstractService<IImageRepository, Image>, IImageService
{
    public ImageService(IImageRepository repository) : base(repository)
    {
    }
    public async Task<byte[]> ConvertImageToByteAsync(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Путь к файлу не может быть пустым.", nameof(path));

        if (!File.Exists(path))
            throw new FileNotFoundException("Файл не найден.", path);

        return await File.ReadAllBytesAsync(path);
    }

    public Task<List<Image>> GetImagesByEquipmentId(int equipmentId)
    {
        return _repository.GetImagesByReportId(equipmentId);
    }

    public async Task<List<Image>> GetImagesByReportId(int reportId)
    {
        return await _repository.GetImagesByReportId(reportId);
    }
    public async Task DeleteImagesByReportId(int reportId)
    {
        var images = await _repository.GetImagesByReportId(reportId);
        foreach(var image in images)
        {
            await _repository.DeleteAsync(image.Id);
        }
    }
    public string GetDataUrl(Image img)
    {
        if (img?.Data is null || img.Data.Length == 0) return string.Empty;
        var mime = GuessMime(img.Data);
        var b64 = Convert.ToBase64String(img.Data);
        return $"data:{mime};base64,{b64}";
    }

    public string GuessMime(byte[] data)
    {
        if (data.Length > 3 && data[0] == 0xFF && data[1] == 0xD8 && data[2] == 0xFF) return "image/jpeg";
        if (data.Length > 8 && data[0] == 0x89 && data[1] == 0x50 && data[2] == 0x4E && data[3] == 0x47) return "image/png";
        if (data.Length > 4 && data[0] == 0x47 && data[1] == 0x49 && data[2] == 0x46 && data[3] == 0x38) return "image/gif";
        if (data.Length > 12 && data[0] == 0x52 && data[1] == 0x49 && data[2] == 0x46 && data[3] == 0x46 &&
            data[8] == 0x57 && data[9] == 0x45 && data[10] == 0x42 && data[11] == 0x50) return "image/webp";
        return "image/jpeg";
    }
}
