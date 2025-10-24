using AutoMapper;
using QazaqGeoReports.Application.DTOs;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Interfaces.Repositories;
using QazaqGeoReports.Domain.Interfaces.Services;

namespace QazaqGeoReports.Application.Services;
public class ReportService : AbstractService<IReportRepository, Report>, IReportService
{
    private readonly IImageService _imageService;
    private readonly IMapper mapper;

    public ReportService(IReportRepository repository, IImageService imageService, IMapper mapper) : base(repository)
    {
        _imageService = imageService;
        this.mapper = mapper;
    }
    public async Task<IEnumerable<Report>> GetReportsByUserAsync(string userId)
    {
        var reports = await _repository.GetReportsByUserAsync(userId);
        return reports;
    }
    public async Task<ReportDto?> GetReportByIdAsync(int id)
    {
        var report = await _repository.GetByIdAsync(id);
        if (report == null)
            return null;
        var dto = mapper.Map<ReportDto>(report);

        dto = new ReportDto { Images = await _imageService.GetImagesByReportId(id) };
        
        return dto;
    }
    public async Task<User> GetUserByReportIdAsync(int reportId)
    {
        return await _repository.GetUserByReportId(reportId);
    }

}
