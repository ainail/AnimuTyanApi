using DataAccess.Dto;

namespace DataAccess.Repository.Base;

public interface IBaseRepository<TDto> where TDto : class, IDto
{
    IQueryable<TDto> GetAll();

    Task<TDto> GetById(Guid id);

    Task<Guid> Create(TDto dto);

    Task Update(Guid id, TDto dto);

    Task Delete(Guid id);
}