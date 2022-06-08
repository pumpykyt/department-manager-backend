namespace DepartmentManager.Data.Entities;

public class Report : BaseEntity
{
    public string Text { get; set; }
    public string UserId { get; set; }
    public string ApartmentId { get; set; }
    public virtual Apartment Apartment { get; set; }
    public virtual User User { get; set; }
}