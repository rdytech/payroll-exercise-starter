namespace Payroll.Api.Data;

public enum EmploymentType
{
    FullTime,
    PartTime,
    Casual,
}

public class Employee
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal HourlyRate { get; set; }
    public EmploymentType EmploymentType { get; set; }
}
