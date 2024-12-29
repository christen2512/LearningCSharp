using Microsoft.EntityFrameworkCore;

namespace Advanced.Models;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Person> People => Set<Person>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Location> Locations => Set<Location>();
}