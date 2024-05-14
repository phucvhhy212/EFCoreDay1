using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Salary> Salaries { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
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
        modelBuilder.Entity<Employee>().HasData(new Employee
        {
            Id = Guid.NewGuid(),
            Name = "Huy Phuc"
        });
        modelBuilder.Entity<Project>().HasData(new Project
        {
            Id = Guid.NewGuid(),
            Name = "Project 1"
        });
        modelBuilder.Entity<Department>().HasQueryFilter(x => x.DeletedAt == null);
        modelBuilder.Entity<Employee>().HasQueryFilter(x => x.DeletedAt == null);
        modelBuilder.Entity<Project>().HasQueryFilter(x => x.DeletedAt == null);
    }
}