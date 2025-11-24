using AutoMapper;  
using QazaqGeoReports.Application.DTOs.ReportDtos;
using QazaqGeoReports.Application.DTOs.UserDtos;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Application.Interfaces.Services;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Services;
public class ReportService : AbstractService<IReportRepository, Report, CreateReportDto, UpdateReportDto, BaseReportDto, ListReportViewModel>,
    IReportService
{
    private readonly IImageService _imageService;
    private readonly IMapper mapper;

    public ReportService(IReportRepository repository, IImageService imageService, IMapper mapper) : base(repository, mapper)
    {
        _imageService = imageService;
        this.mapper = mapper;
    }

    public async Task<List<BaseReportDto>> GetReportsByUserAsync(string userId)
    {
        var reports = await _repository.GetReportsByUserAsync(userId);
        return mapper.Map<List<BaseReportDto>>(reports);
    }
    public async Task<BaseUserDto> GetUserByReportIdAsync(int reportId)
    {
        var report = await _repository.GetByIdAsync(reportId);
        return mapper.Map<BaseUserDto>(report.CreatedByUser);
    }
    public async Task<int> GetReportCountByUserId(string userId)
    {
        var res = await _repository.GetReportsByUserAsync(userId);
        return res.Count;
    }
    public async Task DeleteAllDataReportAsync(int reportId)
    {
        var deletedReport = await _repository.DeleteAsync(reportId);
        await _imageService.DeleteImagesByReportId(reportId);
    }
    public string TripDuratation(BaseReportDto report)
    {
        if (report?.DepartureTime is DateTime dep && report?.ArrivalTime is DateTime arr && arr > dep)
        {
            var ts = arr - dep;
            return $"{(int)ts.TotalHours} ч {ts.Minutes:D2} мин";
        }
        return "—";
    }

    public string FuelPer100(BaseReportDto report)
    {
        if (report?.FuelUsedLiters is double fuel && report?.DistanceKM is double km && km > 0)
        {
            var v = fuel / km * 100.0;
            return v.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture);
        }
        return "—";
    }

    public string TripBadgeText(BaseReportDto report)
    {
        if (report?.DepartureTime is null || report?.ArrivalTime is null) return "время не указано";
        if (report!.ArrivalTime <= report!.DepartureTime) return "проверь время";
        return "данные корректны";
    }
}
