using DataAccess.Dto;
using DataAccess.Repository.Base;

namespace Logic.Services.BaseService;

public abstract class BaseCrudService<TEntity, TDto, TRepository>
where TRepository : IBaseRepository<TDto>
where TDto : class, IDto
{
    private readonly TRepository _repository;
    public BaseCrudService(TRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Insert(TEntity entity)
    {
        var dto = MapToDto(entity);
        return await _repository.Create(dto);
    }

    public async Task<TEntity> Get(Guid id)
    {
        var dto = await _repository.GetById(id);
        return MapToEntity(dto);
    }

    public async Task Update(Guid id, TEntity entity)
    {
        var dto = MapToDto(entity);
        await _repository.Update(id, dto);
    }

    public async Task Delete(Guid id)
    {
        await _repository.Delete(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        var allDtos = _repository.GetAll();
        foreach (var dto in allDtos)
        {
            yield return MapToEntity(dto);
        }
    }

    protected abstract TEntity MapToEntity(TDto dto);

    protected abstract TDto MapToDto(TEntity entity);
}