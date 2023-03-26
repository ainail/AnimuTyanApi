using Logic.Services.Tyan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimuTyanApi.Controllers.Tyan;

[Authorize]
public class TyanController : BaseController
{
    private TyanService _animeTyanService;
    public TyanController(TyanService animeTyanService)
    {
        _animeTyanService = animeTyanService;
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<TyanResponse> Get([FromRoute] Guid id)
    {
        var entity = await _animeTyanService.Get(id);
        var response = MapToResponse(entity);
        return response;
    }


    [Authorize]
    [HttpPost]
    public Task<Guid> Post(TyanInsertRequest request)
    {
        return _animeTyanService.Insert(new TyanEntity(
            null, request.Name, request.Surname, request.Age));
    }


    [Authorize]
    [HttpGet]
    public IEnumerable<TyanResponse> GetAll()
    {
        var entities = _animeTyanService.GetAll();
        foreach (var entity in entities)
        {
            yield return MapToResponse(entity);
        }
    }


    [Authorize]
    [HttpDelete]
    public Task Delete(Guid id)
    {
        return _animeTyanService.Delete(id);
    }

    [HttpPut]
    public Task Put(TyanUpdateRequest request)
    {
        return _animeTyanService
            .Update(request.Id, new TyanEntity(request.Id, request.Name, request.Surname, request.Age));
    }


    [Authorize]
    private TyanResponse MapToResponse(TyanEntity entity)
    {
        var response = new TyanResponse(entity.Id, entity.Name, entity.Surname, entity.Age);
        return response;
    }
}