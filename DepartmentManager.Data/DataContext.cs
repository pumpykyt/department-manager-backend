using DepartmentManager.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DepartmentManager.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Rule> Rules { get; set; }
    public virtual DbSet<Report> Reports { get; set; }
    public virtual DbSet<Apartment> Apartments { get; set; }
}