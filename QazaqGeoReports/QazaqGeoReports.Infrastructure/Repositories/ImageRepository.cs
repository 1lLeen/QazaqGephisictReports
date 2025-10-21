using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Interfaces.Repositories;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class ImageRepository : AbstractRepository<Image>, IImageRepository
{
    public ImageRepository(QazaqGeoReportContext context) : base(context)
    {
    }

    public async Task<List<Image>> GetImagesByEquipmentId(int equipmentId) => await _context.Images.Where(x => x.EquipmentId == equipmentId).ToListAsync();

    public async Task<List<Image>> GetImagesByReportId(int reportId) => await _context.Images.Where(x => x.ReportId == reportId).ToListAsync();
}
