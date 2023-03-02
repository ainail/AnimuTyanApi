using DataAccess.DbContext;
using DataAccess.Dto;
using DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Base;

public class BaseRepository<TDto> : IBaseRepository<TDto>
    where TDto : class, IDto
{
    protected readonly AnimeTyanContext DbContext;

    public BaseRepository(AnimeTyanContext dbContext)
    {
        DbContext = dbContext;
    }

    public IQueryable<TDto> GetAll()
    {
        return DbContext.Set<TDto>().AsNoTracking();
    }

    public async Task<TDto> GetById(Guid id)
    {
        var dto = await DbContext.Set<TDto>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (dto == null)
            throw new NotFoundException();
        return dto;
    }

    public async Task<Guid> Create(TDto dto)
    {
        await DbContext.Set<TDto>().AddAsync(dto);
        await DbContext.SaveChangesAsync();
        return dto.Id;
    }

    public async Task Update(Guid id, TDto dto)
    {
        DbContext.Set<TDto>().Update(dto);
        await DbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var entity = await GetById(id);
        DbContext.Set<TDto>().Remove(entity);
        await DbContext.SaveChangesAsync();
    }
}