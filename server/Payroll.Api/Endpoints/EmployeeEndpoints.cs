using Microsoft.EntityFrameworkCore;
using Payroll.Api.Data;

namespace Payroll.Api.Endpoints;

public static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/employees", async (PayrollDbContext db) =>
            await db.Employees
                .AsNoTracking()
                .OrderBy(e => e.Id)
                .ToListAsync());
    }
}
