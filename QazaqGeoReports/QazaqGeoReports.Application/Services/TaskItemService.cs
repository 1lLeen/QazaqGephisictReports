using AutoMapper;
using QazaqGeoReports.Application.DTOs.TaskItemDtos;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Application.Interfaces.Services;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Services;

public class TaskItemService : AbstractService<ITaskItemRepository, TaskItem, CreateTaskItemDto, UpdateTaskItemDto, BaseTaskItemDto, ListTaskItemViewModel>,
    ITaskItemService
{
    public TaskItemService(ITaskItemRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
