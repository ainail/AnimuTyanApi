using DataAccess.DbContext;
using DataAccess.Dto;
using DataAccess.Repository.Base;

namespace DataAccess.Repository;

public class TyanRepository : BaseRepository<TyanDto>, IBaseRepository<TyanDto>
{
    public TyanRepository(AnimeTyanContext dbContext) : base(dbContext)
    {
    }
}