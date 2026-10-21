namespace Payroll.Api.Data;

public static class SeedData
{
    // Creates the database from the model if it doesn't exist, then loads the sample employees.
    // There are no migrations: after changing the model, run `npm run db:reset`.
    public static void Initialise(PayrollDbContext db)
    {
        db.Database.EnsureCreated();

        if (db.Employees.Any())
        {
            return;
        }

        db.Employees.AddRange(
            new Employee { Name = "Alice", HourlyRate = 50.00m, EmploymentType = EmploymentType.FullTime },
            new Employee { Name = "Bob", HourlyRate = 40.00m, EmploymentType = EmploymentType.PartTime },
            new Employee { Name = "Charlie", HourlyRate = 30.00m, EmploymentType = EmploymentType.Casual },
            new Employee { Name = "Dana", HourlyRate = 28.30m, EmploymentType = EmploymentType.FullTime });

        db.SaveChanges();
    }
}
