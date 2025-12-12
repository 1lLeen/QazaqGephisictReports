using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Infrastructure.Repositories;

public class TaskItemRepository : AbstractRepository<TaskItem>,
    ITaskItemRepository
{
    public TaskItemRepository(QazaqGeoReportContext context) : base(context)
    {
    }
}
