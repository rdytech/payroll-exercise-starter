# Payroll exercise starter

React + .NET + SQLite. The UI, API and database are already connected, and four employees are loaded.

## Layout
- `client/`                      React + TypeScript (Vite) UI, http://localhost:5173
- `client/src/api.ts`            Fetch calls to the API
- `server/Payroll.slnx`          .NET solution
- `server/Payroll.Api/`          ASP.NET Core minimal API, http://localhost:5080
- `server/Payroll.Api/Data/`     EF Core `PayrollDbContext`, entities and seed data
- `server/Payroll.Api/Endpoints/` Endpoint mappings
- `server/Payroll.Tests/`        xUnit tests; `PayrollApiFactory` starts the API in memory on a throwaway database
- `scripts/`                     Helper scripts used by npm commands

The Vite dev server proxies `/api/*` to the API, so the client calls relative URLs such as `/api/employees`.

## Running the app
- The user runs `npm run dev` in their own terminal and keeps it running. On save, the API restarts (about 3 seconds; hot reload is off so new endpoints always take effect) and the UI reloads.
- **Don't start another copy** of `npm run dev`, `dotnet run` or `dotnet watch`: the ports are fixed (5080, 5173), and on Windows a stopped background copy can keep holding them.
- To check a change, run `npm test`, or call the running API, e.g. `curl http://localhost:5080/api/employees`.
- If the app isn't running, ask the user to start it.

## Commands (run from the repo root)
- `npm install`        Install client dependencies and restore .NET packages
- `npm run dev`        Start the API and UI together
- `npm run dev:fresh`  Delete the database, then start the API and UI (use after changing the EF Core model)
- `npm test`           Run all tests once (.NET, then client); safe to run while the app is running
- `npm run test:api`   Run only the .NET tests
- `npm run db:reset`   Delete the SQLite database (the app must be stopped)

## Database
- SQLite file at `server/Payroll.Api/payroll.db`, created on API start with `EnsureCreated()` and seeded in `Data/SeedData.cs`.
- There are no migrations, and an existing database is **not** updated when the model changes. After adding or changing an entity, the API returns `no such table` / `no such column` errors until the database is recreated: ask the user to stop the app (Ctrl+C) and run `npm run dev:fresh`.
- Tests always use a new database, so they aren't affected.
- In Development, 500 responses include the exception message in the `detail` field.

## Tech versions
- .NET 10 (pinned in `global.json`), ASP.NET Core minimal APIs, EF Core 10 with SQLite
- xUnit 2 and `Microsoft.AspNetCore.Mvc.Testing`
- Node 22+, React 19, Vite 8, TypeScript (strict), Vitest

## Conventions
- C#: nullable reference types on; file-scoped namespaces; format with `dotnet format server/Payroll.slnx`
- TypeScript: strict mode; client tests go next to the code as `*.test.ts(x)`
- JSON uses camelCase; enums are serialised as strings
