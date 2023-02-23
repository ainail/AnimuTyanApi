using System.ComponentModel.DataAnnotations;

namespace AnimuTyanApi.Controllers.Tyan;

public class TyanInsertRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public int Age { get; set; }
}