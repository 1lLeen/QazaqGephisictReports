using Microsoft.EntityFrameworkCore;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class ImageRepository : AbstractRepository<Image>, IImageRepository
{
    public ImageRepository(QazaqGeoReportContext context) : base(context)
    {
    }
    public async Task<List<Image>> GetImagesByEquipmentId(int equipmentId) => await _context.Images
        .Include(x => x.Equipment)
        .AsNoTracking()
        .ToListAsync();

    public async Task<List<Image>> GetImagesByReportId(int reportId) => await _context.Images
        .Include(x => x.Report)
        .AsNoTracking()
        .ToListAsync();
}
