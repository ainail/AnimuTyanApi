using DataAccess.DbContext;
using DataAccess.Dto;
using DataAccess.Exceptions;
using DataAccess.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class UserRepository : BaseRepository<UserDto>, IBaseRepository<UserDto>
{
    public UserRepository(AnimeTyanContext dbContext) : base(dbContext)
    {
    }

    public async Task<UserDto> FindByNameAsync(string username, string password)
    {
        var dto = await DbContext.Set<UserDto>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Username == username && e.Password == password);

        if (dto == null)
            throw new NotFoundException();
        return dto;
    }
}