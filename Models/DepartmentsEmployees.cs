using System.ComponentModel.DataAnnotations;

namespace web_api.Models;

public class DepartmentsEmployees {
    [Key]
    public int Id { get; set; }

    public string? Created_by { get; set; }
    public DateTime? Created_date { get; set; }
    public string? Modified_by { get; set; }
    public DateTime? Modified_date { get; set; }
    public bool? Status { get; set; }
    public int? Id_department { get; set; }
    public int? Id_employee { get; set; }
}