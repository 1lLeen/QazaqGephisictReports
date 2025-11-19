using AutoMapper;
using QazaqGeoReports.Application.DTOs.EquipmentDtos;
using QazaqGeoReports.Application.Interfaces.Repositories;
using QazaqGeoReports.Application.Interfaces.Services; 
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Services;
public class EquipmentService : AbstractService<IEquipmentRepository, Equipment, CreateEquipmentDto, UpdateEquipmentDto, BaseEquipmentDto, ListEquipmentViewModel>, 
    IEquipmentService
{ 
    public EquipmentService(IEquipmentRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
