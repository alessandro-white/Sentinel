# Sentinel

Sentinel is a backend service monitoring and automated incident tracking application.

This repository contains the ASP.NET Core API, a background job runner (Worker Service), and the shared Entity Framework Core infrastructure.

## Prerequisites

To run this stack locally, you need the following tools installed:
* **Docker Desktop**.
* **.NET SDK** (version 10.0).
* **Entity Framework Core CLI**. Install globally via terminal:
  ```bash
  dotnet tool install --global dotnet-ef
  ```
* An IDE such as **JetBrains Rider**, Visual Studio, or VS Code.

## Environment Setup

To keep credentials out of source control, local environment variables are managed via a `.env` file.

1. At the root of the `Sentinel` directory, create a file named `.env`.
2. Add your local database password:
   ```env
   SA_PASSWORD=YourStrong!Password123
   ```

## Running the Application

The entire stack (API, Worker, and SQL Server) is containerised and managed via Docker Compose.

**Start the stack:**
Builds the images and starts the containers in the background.
```bash
docker compose up -d --build
```

**Verify the API is running:**
The API health check is mapped to port 5001.
```bash
curl -i http://localhost:5001/health
```

**View logs:**
```bash
docker compose logs -f
```

**Stop the stack:**
Stops the containers but preserves your database data in a Docker named volume.
```bash
docker compose down
```

## Database Migrations

Sentinel uses Entity Framework Core with a code-first approach. The database runs in Docker on port `1433`, but migration commands are executed from your host machine.

Run these commands from the repo root in a Bash or Zsh terminal. Docker Compose uses `compose.yaml` to supply the connection string inside the containers. For EF commands on your host, load `SA_PASSWORD` from your `.env` and set the connection string in that terminal.

```bash
docker compose up -d --wait sentinel.sql
source ./.env
export ConnectionStrings__DefaultConnection="Server=localhost,1433;Database=SentinelDb;User Id=sa;Password=\"${SA_PASSWORD//\"/\"\"}\";TrustServerCertificate=True;"
```

**1. Create a new migration:**
Run this from the root directory whenever you change your domain entities:
```bash
dotnet ef migrations add <MigrationName> --project src/Sentinel.Infrastructure --startup-project src/Sentinel.Api
```

**2. Apply migrations to the database:**
Run this to create the database or update the schema:
```bash
dotnet ef database update --project src/Sentinel.Infrastructure --startup-project src/Sentinel.Api
```
