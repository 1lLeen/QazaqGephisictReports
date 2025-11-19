using AutoMapper;
using QazaqGeoReports.Application.DTOs.Common; 
using QazaqGeoReports.Application.Interfaces.Dtos; 

namespace QazaqGeoReports.Application.DTOs.Helpers;

public static class ResultBuilder
{
    public static ResultDto<TDto> Build<TDto, TSource>(TSource source, IMapper mapper)
        where TDto : IBase 
    {
        if (source is null)
        {
            return new ResultDto<TDto>
            {
                Success = false,
                Error = "Not found"
            };
        }

        return new ResultDto<TDto>
        {
            Success = true,
            Data = mapper.Map<TDto>(source)
        };
    }
    public static ResultDto<List<TDto>> BuildList<TDto, TSource>(List<TSource>? source, IMapper mapper)
        where TDto : IBase
    {
        if (source is null)
        {
            return new ResultDto<List<TDto>>
            {
                Success = false,
                Error = "Not found"
            };
        }

        return new ResultDto<List<TDto>>
        {
            Success = true,
            Data = mapper.Map<List<TDto>>(source)
        };
    }
    public static ResultDto<T> Build<T>(T source)
    {
        if (!typeof(T).IsValueType && source is null)
        {
            return new ResultDto<T>
            {
                Success = false,
                Error = "Value is null"
            };
        }
         
        return new ResultDto<T>
        {
            Success = true,
            Data = source
        };
    }
}
