using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;

namespace Payroll.Api;

// Development only: puts the exception message in the 500 response, so the cause is visible
// from the browser or curl, not just in the API's console output.
public static class DevelopmentErrors
{
    public static void AddExceptionDetail(ProblemDetailsContext context)
    {
        var exception = context.HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception is null || context.ProblemDetails.Detail is not null)
        {
            return;
        }

        var sqlite = exception as SqliteException ?? exception.InnerException as SqliteException;
        var message = sqlite?.Message ?? exception.Message;

        // The database is created once from the model (EnsureCreated), so it doesn't pick up new
        // tables or columns until it is recreated.
        if (message.Contains("no such table") || message.Contains("no such column"))
        {
            message += " The database was created before the model changed: stop the app (Ctrl+C) and run `npm run dev:fresh`.";
        }

        context.ProblemDetails.Detail = message;
    }
}
