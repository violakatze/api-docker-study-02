using System.ComponentModel.DataAnnotations;

namespace ApiDockerStudy.Entities;

public class Book
{
    public int Id { get; set; }
    [MaxLength(200)]
    public required string Title { get; set; }
    [MaxLength(100)]
    public required string Author { get; set; }
}
