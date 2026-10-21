using System.Net.Http.Json;

namespace Payroll.Tests;

public class EmployeeEndpointTests(PayrollApiFactory factory) : IClassFixture<PayrollApiFactory>
{
    private record EmployeeDto(int Id, string Name, decimal HourlyRate, string EmploymentType);

    [Fact]
    public async Task Get_employees_returns_the_four_seeded_employees()
    {
        var client = factory.CreateClient();

        var employees = await client.GetFromJsonAsync<List<EmployeeDto>>("/api/employees");

        Assert.NotNull(employees);
        Assert.Equal(["Alice", "Bob", "Charlie", "Dana"], employees.Select(e => e.Name));
    }
}
