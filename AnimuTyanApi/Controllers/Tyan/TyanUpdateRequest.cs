using System.ComponentModel.DataAnnotations;

namespace AnimuTyanApi.Controllers.Tyan;

public class TyanUpdateRequest
{
    [Required]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int? Age { get; set; }
}