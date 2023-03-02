using Logic.Services.BaseService;

namespace Logic.Services.Tyan;

public class TyanEntity : BaseIdentityEntity
{
    public string Name { get; }

    public string Surname { get; }

    public int? Age { get; }

    public TyanEntity(Guid? id, string name, string surname, int? age) : base (id)
    {
        Name = name;
        Surname = surname;
        Age = age;
    }
}