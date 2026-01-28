using QazaqGeoReports.Application.Interfaces.Dtos;
using QazaqGeoReports.Domain.Common;
using QazaqGeoReports.Domain.Entities;
using QazaqGeoReports.Domain.Entities.Users;

namespace QazaqGeoReports.Application.DTOs.TaskItemDtos;

public class BaseTaskItemDto : IBase
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }

    public TaskItemStatus Status { get; set; }   // New, InProgress, Done, Failed

    public string? AssignedUserId { get; set; }
    public User? AssignedUser { get; set; }

    public int? MissionId { get; set; }
    public Mission? Mission { get; set; }
}
