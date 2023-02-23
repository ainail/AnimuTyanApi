namespace Logic.Services.BaseService;

public class BaseIdentityEntity : IBaseIdentityEntity
{
    public Guid Id { get; }

    public BaseIdentityEntity(Guid id)
    {
        Id = id;
    }


    public BaseIdentityEntity()
    {
        Id = Guid.NewGuid();
    }
}