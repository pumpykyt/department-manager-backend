namespace DepartmentManager.Data.Entities;

public class User : BaseEntity
{
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }
    public string? ApartmentId { get; set; }
    public virtual ICollection<Report> Reports { get; set; }
    public virtual Apartment Apartment { get; set; }
}