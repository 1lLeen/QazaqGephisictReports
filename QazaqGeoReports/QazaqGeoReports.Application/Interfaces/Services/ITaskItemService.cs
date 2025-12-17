using QazaqGeoReports.Application.DTOs.TaskItemDtos;

namespace QazaqGeoReports.Application.Interfaces.Services;

public interface ITaskItemService : IAbstractService<BaseTaskItemDto, CreateTaskItemDto, UpdateTaskItemDto>
{
}
