using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Data;

public class TestAPIDbContext : DbContext
{
    public TestAPIDbContext(DbContextOptions<TestAPIDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<JobTitle> JobTitles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Entity<Employee>()
        .HasMany(p => p.JobTitles)
        .WithMany(p => p.Employees)
        .UsingEntity(j => j.ToTable("EmployeesJobTitles"));
    }
}
