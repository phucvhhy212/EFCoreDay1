using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Salary> Salaries { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "server=(local);database=NashTech;TrustServerCertificate=true;Integrated Security=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().Property(d => d.Name).HasMaxLength(40).IsRequired();
        modelBuilder.Entity<Employee>().Property(d => d.Name).HasMaxLength(40).IsRequired();
        modelBuilder.Entity<Project>().Property(d => d.Name).HasMaxLength(40).IsRequired();
        modelBuilder.Entity<ProjectEmployee>().HasKey(c => new { c.EmployeeId, c.ProjectId });
        modelBuilder.Entity<Department>().HasData(new Department
        {
            Id = Guid.NewGuid(),
            Name = "Software Development"
        }, new Department
        {
            Id = Guid.NewGuid(),
            Name = "Finance"
        }, new Department
        {
            Id = Guid.NewGuid(),
            Name = "Accountant"
        }, new Department
        {
            Id = Guid.NewGuid(),
            Name = "HR"
        });
    }
}