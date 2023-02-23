using DataAccess.Dto;
using DataAccess.Repository;
using Logic.Services.BaseService;

namespace Logic.Services.AnimeTyan;

public class AnimeTyanService : BaseCrudService<TyanEntity, TyanDto, TyanRepository>
{
    private readonly TyanRepository _tyanRepo;
    public AnimeTyanService(TyanRepository tyanRepo) : base(tyanRepo)
    {
        _tyanRepo = tyanRepo;
    }

    protected override TyanEntity MapToEntity(TyanDto dto)
    {
        var entity = new TyanEntity(
            dto.Id,
            dto.Name,
            dto.Surname,
            dto.Age);
        return entity;
    }

    protected override TyanDto MapToDto(TyanEntity identityIdentityEntity)
    {
        var dto = new TyanDto
        {
            Age = identityIdentityEntity.Age,
            Name = identityIdentityEntity.Name,
            Surname = identityIdentityEntity.Surname,
            Id = identityIdentityEntity.Id
        };
        return dto;
    }
}