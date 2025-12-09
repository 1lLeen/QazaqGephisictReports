using QazaqGeoReports.Application.DTOs.ImageDtos.ImageReportDtos;

namespace QazaqGeoReports.Application.Interfaces.Services.ImagesServices;

public interface IImageReportService : 
    IImageAbstractService<BaseImageReportDto, CreateImageReportDto, UpdateImageReportDto>
{
    Task<List<BaseImageReportDto>> GetImagesByReportIdAsync(int reportId);
    Task DeleteAllImagesByReportIdAsync(int reportId);
}
