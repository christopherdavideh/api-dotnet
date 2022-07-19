using System.ComponentModel.DataAnnotations;

namespace web_api.Models;

public class Employees {
    [Key]
    public int Id { get; set; }

    public string? Created_by { get; set; }
    public DateTime? Created_date { get; set; }
    public string? Modified_by { get; set; }
    public DateTime? Modified_date { get; set; }
    public bool? Status { get; set; }
    public int? Age { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Position { get; set; }
    public string? Surname { get; set; }
    public int[]? Departments { get; set; }
}