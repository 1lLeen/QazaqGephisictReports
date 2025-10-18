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
}
