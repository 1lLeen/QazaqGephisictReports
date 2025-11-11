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
    public async Task<List<Report>> GetReportsByUserAsync(string userId)
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
     
    public string TripDuratation(Report report)
    {
        if (report?.DepartureTime is DateTime dep && report?.ArrivalTime is DateTime arr && arr > dep)
        {
            var ts = arr - dep;
            return $"{(int)ts.TotalHours} ч {ts.Minutes:D2} мин";
        }
        return "—";
    }

    public string FuelPer100(Report report)
    {
        if (report?.FuelUsedLiters is double fuel && report?.DistanceKM is double km && km > 0)
        {
            var v = fuel / km * 100.0;
            return v.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture);
        }
        return "—";
    }

    public string TripBadgeText(Report report)
    {
        if (report?.DepartureTime is null || report?.ArrivalTime is null) return "время не указано";
        if (report!.ArrivalTime <= report!.DepartureTime) return "проверь время";
        return "данные корректны";
    }
}
