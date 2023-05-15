using System.ComponentModel.DataAnnotations;

namespace BestMoviesApp.Models;

public class Movie
{
    public long Id { get; set; }
    [Required]
    [StringLength(16, ErrorMessage = "Identifier too long (16 character limit).")]
    public string? Title { get; set; } = null!;
    public int Year { get; set; }
    public string? Url { get; set; }
}