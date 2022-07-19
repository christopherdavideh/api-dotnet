using System.ComponentModel.DataAnnotations;

namespace web_api.Models;

public class Enterprises {
    [Key]
    public int Id { get; set; }

    public string? Created_by { get; set; }
    public DateTime? Created_date { get; set; }
    public string? Modified_by { get; set; }
    public DateTime? Modified_date { get; set; }
    public bool? Status { get; set; }
    public string? Address { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
}