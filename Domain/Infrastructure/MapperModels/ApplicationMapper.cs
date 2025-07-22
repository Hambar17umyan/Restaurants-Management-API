using AutoMapper;
using Domain.Infrastructure.ResultModels;
using FluentResults;

namespace Domain.Infrastructure.MapperModels;

public class ApplicationMapper(IMapper mapper)
{
    private readonly IMapper _mapper = mapper;

    public Result<TDestination> Map<TSource, TDestination>(TSource source)
        where TSource : class
        where TDestination : class
    {
        ArgumentNullException.ThrowIfNull(source);
        try
        {
            var destination = this._mapper.Map<TDestination>(source);
            return Result.Ok(destination);
        }
        catch (AutoMapperMappingException ex)
        {
            return ResultHelper.ErrorResult<TDestination>(ErrorType.MappingError, $"Mapping error: {source.GetType().FullName} -> {typeof(TDestination)}.\n\nException:\n{ex}");
        }
    }
}
