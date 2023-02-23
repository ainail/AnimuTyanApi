using DataAccess.DbContext;
using DataAccess.Dto;
using DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Base;

public class BaseRepository<TDto> : IBaseRepository<TDto>
    where TDto : class, IDto
{
    private readonly AnimeTyanContext _dbContext;

    public BaseRepository(AnimeTyanContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<TDto> GetAll()
    {
        return _dbContext.Set<TDto>().AsNoTracking();
    }

    public async Task<TDto> GetById(Guid id)
    {
        var dto = await _dbContext.Set<TDto>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (dto == null)
            throw new NotFoundException();
        return dto;
    }

    public async Task<Guid> Create(TDto dto)
    {
        await _dbContext.Set<TDto>().AddAsync(dto);
        await _dbContext.SaveChangesAsync();
        return dto.Id;
    }

    public async Task Update(Guid id, TDto dto)
    {
        _dbContext.Set<TDto>().Update(dto);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var entity = await GetById(id);
        _dbContext.Set<TDto>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}