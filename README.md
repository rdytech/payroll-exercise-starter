# Payroll exercise starter

A small React + .NET + SQLite app for the ReadyTech technical assessment. The web page, REST API and database are already connected, and four employees are loaded. You'll build the features during the interview.

> **Please don't build the features in advance.** Just check that everything below works, ideally on the same laptop and network you'll use on the day.
>
> **Please clone this repository rather than forking it, and keep your work private.** Don't push your changes to GitHub or share them anywhere public, before or after the interview, so the exercise stays fair for other candidates.

## 1. Install the prerequisites

| Tool | Version | Check with |
|---|---|---|
| [.NET SDK](https://dotnet.microsoft.com/download/dotnet/10.0) | 10.0.100 or later | `dotnet --version` |
| [Node.js](https://nodejs.org/) | 22 or later | `node --version` |
| [Git](https://git-scm.com/downloads) | any recent version | `git --version` |
| [VS Code](https://code.visualstudio.com/) | latest | |
| C# Dev Kit extension | latest | VS Code suggests it when you open the folder |
| Your AI coding agent (for example Claude Code) | latest | it can edit files and run terminal commands |

## 2. Set up

Open a terminal in a folder of your choice, for example `C:\dev` or `~/dev`, and run the commands below. Avoid OneDrive or other synced folders, which can lock files while the app is running. You don't need a GitHub account.

```bash
git clone https://github.com/rdytech/payroll-exercise-starter.git
cd payroll-exercise-starter
npm install
```

Then open the `payroll-exercise-starter` folder in VS Code (**File → Open Folder**).

The clone gives you a clean starting point, so during the interview you and your agent can see exactly what changed with `git diff` or VS Code's Source Control view. Commit locally as often as you like, but don't push. `npm install` installs the web dependencies and restores the .NET packages. The first run of .NET on a new machine also does some one-off setup, which is one reason to do this before the day.

## 3. Check it works (about 10 minutes)

1. **Run the app:** in a VS Code terminal, run `npm run dev`, then open http://localhost:5173. You should see **Alice, Bob, Charlie and Dana** in the employee table. Leave it running.
2. **Run the tests:** in a **second** terminal, run `npm test`. You should see `Passed! - Failed: 0, Passed: 1`.
3. **Check your agent:** start your agent in the project folder and ask it to *"run `npm test` and tell me the result"*. Confirm that it can run the command and edit a file, and that it **doesn't need you to approve every command**. In Claude Code, allow `npm` and `dotnet` commands with `/permissions`, or pick the permission mode you're comfortable with.
4. **Check a restart:** stop the app with `Ctrl+C`, then run `npm run dev:fresh`. The app should start again with the same four employees.

If all four work, you're ready. Stop the app with `Ctrl+C`. If anything doesn't, let us know before the interview.

## Commands

| Command | What it does |
|---|---|
| `npm run dev` | Starts the API (http://localhost:5080) and web page (http://localhost:5173). When you save, the API restarts (a few seconds) and the page reloads |
| `npm run dev:fresh` | Deletes the database, then starts the app. Use it after changing the data model |
| `npm test` | Runs all tests once. Fine to run while the app is running |
| `npm run test:api` | Runs only the .NET tests |
| `npm run db:reset` | Deletes the database (stop the app first) |

In VS Code you can also use **Terminal → Run Task** (`dev: API + web`, `test: all`) and **Run and Debug → Debug API**.

**Tip:** keep `npm run dev` running in its own terminal for the whole session, and let your agent use `npm test`. Running two copies of the app fights over the same ports.

## Project layout

```
client/                 React + TypeScript (Vite)
server/
  Payroll.slnx
  Payroll.Api/          ASP.NET Core minimal API + EF Core (SQLite)
  Payroll.Tests/        xUnit tests
scripts/                Helper scripts
AGENTS.md               Project notes for AI agents (CLAUDE.md points to it)
```

## Troubleshooting

- **`no such table` or `no such column`:** the database was created before the data model changed. Stop the app (`Ctrl+C`) and run `npm run dev:fresh`.
- **"Port 5173 is already in use" or "address already in use: 5080":** another copy of the app is still running, perhaps one your agent started. Close the other terminal, or end the leftover `node` / `dotnet` process (in PowerShell: `Get-Process node, dotnet | Stop-Process`, which also closes other Node and .NET programs).
- **The employee table is empty, with "Could not load employees":** the API isn't running, or it returned an error. Check the `[api]` lines in the `npm run dev` output.
- **"The database is in use" from `db:reset`:** stop `npm run dev` first.
- **"Access is denied" when the API starts:** some managed laptops block new `.exe` files. This project already runs the API through `dotnet Payroll.Api.dll` to avoid it. Tell us if you still see it.
- **Something else:** let us know before the interview and we'll help.
