using AutoMapper;
using QazaqGeoReports.Application.DTOs.TaskItemDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Mapper;

public class TaskItemMapperProfile : Profile
{
    public TaskItemMapperProfile()
    {
        CreateMap<BaseTaskItemDto, TaskItem>().ReverseMap();
        CreateMap<CreateTaskItemDto, TaskItem>().ReverseMap();
        CreateMap<UpdateTaskItemDto, TaskItem>().ReverseMap();
        CreateMap<ListTaskItemViewModel, TaskItem>().ReverseMap();
    }
}
