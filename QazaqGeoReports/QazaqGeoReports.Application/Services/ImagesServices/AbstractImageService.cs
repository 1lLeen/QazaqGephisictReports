using AutoMapper;
using QazaqGeoReports.Application.Interfaces.Dtos; 
using QazaqGeoReports.Application.Interfaces.Repositories.ImagesRepositories;
using QazaqGeoReports.Domain.Entities.Images;

namespace QazaqGeoReports.Application.Services.ImagesServices;

public class AbstractImageService<TRepository, TEntity, DtoCreate, DtoUpdate, DtoBase, DtoList>
    where TRepository : IImageAbstractRepository<TEntity>
    where TEntity : BaseImage, new()
    where DtoCreate : ICreate
    where DtoUpdate : IUpdate
    where DtoBase : IImageBase, new()
    where DtoList : IListView
{
    protected readonly TRepository _repository;
    protected readonly IMapper _mapper;

    public AbstractImageService(TRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<DtoBase>> GetImagesAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<List<DtoBase>>(entities);
    } 
    public async Task<DtoBase> GetImageByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<DtoBase>(entity);
    }
    public virtual async Task<DtoBase> CreateAsync(DtoCreate entity)
    {
        var created = await _repository.CreateAsync(_mapper.Map<TEntity>(entity));
        return _mapper.Map<DtoBase>(created);
    }
    public virtual async Task<DtoBase> UpdateAsync(DtoUpdate entity, int id)
    {
        var localEntity = await _repository.GetByIdAsync(id);
        if (localEntity == null)
        {
            throw new KeyNotFoundException($"Entity with id {id} not found.");
        }
        localEntity = _mapper.Map(entity, localEntity);
        var updated = await _repository.UpdateAsync(localEntity);
        return _mapper.Map<DtoBase>(updated);

    }
    public virtual async Task<DtoBase> DeleteAsync(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        return _mapper.Map<DtoBase>(deleted);
    }
    public string GetDataUrl(DtoBase img)
    {
        if (img?.Data is null || img.Data.Length == 0) return string.Empty;
        var mime = GuessMime(img.Data);
        var b64 = Convert.ToBase64String(img.Data);
        return $"data:{mime};base64,{b64}";
    }

    public string GuessMime(byte[] data)
    {
        if (data.Length > 3 && data[0] == 0xFF && data[1] == 0xD8 && data[2] == 0xFF)
            return "image/jpeg";
        if (data.Length > 8 && data[0] == 0x89 && data[1] == 0x50 && data[2] == 0x4E && data[3] == 0x47)
            return "image/png";
        if (data.Length > 4 && data[0] == 0x47 && data[1] == 0x49 && data[2] == 0x46 && data[3] == 0x38)
            return "image/gif";
        if (data.Length > 12 && data[0] == 0x52 && data[1] == 0x49 && data[2] == 0x46 && data[3] == 0x46 &&
            data[8] == 0x57 && data[9] == 0x45 && data[10] == 0x42 && data[11] == 0x50)
            return "image/webp";

        return "image/jpeg";
    }
}
