using AutoMapper;
using QazaqGeoReports.Application.DTOs.ImageDtos.ImageReportDtos;
using QazaqGeoReports.Application.Interfaces.Repositories.ImagesRepositories;
using QazaqGeoReports.Application.Interfaces.Services.ImagesServices;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Application.Services.ImagesServices;

public class ImageReportService : AbstractImageService<IImageReportRepository, ImageReport, CreateImageReportDto, UpdateImageReportDto, BaseImageReportDto, ListImageReportViewModel>,
    IImageReportService

{
    public ImageReportService(IImageReportRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
    public async Task<List<BaseImageReportDto>> GetImagesByReportIdAsync(int reportId)
    {
        var entities = await _repository.GetAllAsync();
        var images = entities.Where(x => x.ReportId == reportId).ToList();
        return _mapper.Map<List<BaseImageReportDto>>(images);
    }
    public async Task DeleteAllImagesByReportIdAsync(int reportId)
    {
        if (reportId < 0)
            return;

        _repository.DeleteAllImagesByReportIdAsync(reportId);
        await Task.CompletedTask;   
    }
}
