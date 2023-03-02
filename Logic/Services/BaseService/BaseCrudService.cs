using DataAccess.Dto;
using DataAccess.Repository.Base;

namespace Logic.Services.BaseService;

public abstract class BaseCrudService<TEntity, TDto, TRepository>
where TRepository : IBaseRepository<TDto>
where TDto : class, IDto
{
    protected readonly TRepository Repository;
    public BaseCrudService(TRepository repository)
    {
        Repository = repository;
    }

    public async Task<Guid> Insert(TEntity entity)
    {
        var dto = MapToDto(entity);
        return await Repository.Create(dto);
    }

    public async Task<TEntity> Get(Guid id)
    {
        var dto = await Repository.GetById(id);
        return MapToEntity(dto);
    }

    public async Task Update(Guid id, TEntity entity)
    {
        var dto = MapToDto(entity);
        await Repository.Update(id, dto);
    }

    public async Task Delete(Guid id)
    {
        await Repository.Delete(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        var allDtos = Repository.GetAll();
        foreach (var dto in allDtos)
        {
            yield return MapToEntity(dto);
        }
    }

    protected abstract TEntity MapToEntity(TDto dto);

    protected abstract TDto MapToDto(TEntity entity);
}