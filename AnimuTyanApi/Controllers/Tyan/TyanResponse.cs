namespace AnimuTyanApi.Controllers.Tyan;

public class TyanResponse
{
    public Guid Id { get; }

    public string Name { get; }

    public string Surname { get; }

    public int? Age { get; }

    public TyanResponse(Guid id, string name, string surname, int? age)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Age = age;
    }
}