using DataAccess.Dto;
using DataAccess.Repository;
using Logic.Services.BaseService;

namespace Logic.Services.User;

public class UserService : BaseCrudService<UserEntity, UserDto, UserRepository>
{
    public UserService(UserRepository repository) : base(repository)
    {
    }

    public async Task<UserEntity> FindByNameAsync(string username, string password)
    {
        return MapToEntity(await Repository.FindByNameAsync(username, password));
    }

    protected override UserEntity MapToEntity(UserDto dto)
    {
        var entity = new UserEntity(dto.Id, dto.Email, dto.Username, dto.Password);
        return entity;
    }

    protected override UserDto MapToDto(UserEntity entity)
    {
        var dto = new UserDto
        {
            Username = entity.Username,
            Email = entity.Email,
            Id = entity.Id,
            Password = entity.Password
        };
        return dto;
    }
}