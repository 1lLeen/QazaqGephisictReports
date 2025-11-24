using AutoMapper;
using QazaqGeoReports.Application.DTOs.EquipmentDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Mapper;

public class EquipmentMapperProfile : Profile
{
    public EquipmentMapperProfile()
    {
        CreateMap<CreateEquipmentDto, Equipment>().ReverseMap();
        CreateMap<UpdateEquipmentDto, Equipment>().ReverseMap();
        CreateMap<BaseEquipmentDto, Equipment>().ReverseMap();
        CreateMap<ListEquipmentViewModel, Equipment>().ReverseMap();
    }
}
