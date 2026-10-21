using Microsoft.EntityFrameworkCore;

namespace Payroll.Api.Data;

public class PayrollDbContext(DbContextOptions<PayrollDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(employee =>
        {
            employee.Property(e => e.Name).IsRequired();
            employee.Property(e => e.EmploymentType).HasConversion<string>();
        });
    }
}
