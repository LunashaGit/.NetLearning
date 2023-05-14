using System.ComponentModel.DataAnnotations;
namespace Todo;

public class Todo
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

}