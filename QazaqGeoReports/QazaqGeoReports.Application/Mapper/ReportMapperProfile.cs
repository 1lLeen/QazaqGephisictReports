using AutoMapper;
using QazaqGeoReports.Application.DTOs.ReportDtos;
using QazaqGeoReports.Domain.Entities;

namespace QazaqGeoReports.Application.Mapper;
public class ReportMapperProfile : Profile
{
    public ReportMapperProfile()
    {
        CreateMap<BaseReportDto, Report>().ReverseMap();
        CreateMap<CreateReportDto, Report>().ReverseMap();
        CreateMap<UpdateReportDto, Report>().ReverseMap();
        CreateMap<ListReportViewModel,  Report>().ReverseMap();
        CreateMap<ReportViewModel, Report>().ReverseMap();
    }
}
