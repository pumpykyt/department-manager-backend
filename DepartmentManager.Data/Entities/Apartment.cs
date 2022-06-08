namespace DepartmentManager.Data.Entities;

public class Apartment : BaseEntity
{
    public string ApartmentNumber { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Report> Reports { get; set; }
}