# TaskManager API

A REST API for task management built with **ASP.NET Core 9**, following **Clean Architecture** principles.

---

## Architecture

The project is structured in 4 layers:

```
TaskManager.API/
├── Domain/          # Entities and interfaces — no external dependencies
├── Application/     # Use Cases — application business rules
├── Infrastructure/  # Persistence implementations (EF Core + SQL Server)
└── Presentation/    # Controllers, Middlewares — HTTP entry point
```

### Principles applied
- **Clean Architecture** — dependencies point inward (toward Domain)
- **SOLID** — especially Single Responsibility and Dependency Inversion
- **Repository Pattern** — abstraction over the persistence layer
- **Use Cases** — each operation has its own isolated class
- **Encapsulation** — Entity with `private set` and domain methods

---

## Tech Stack

| Technology | Purpose |
|---|---|
| ASP.NET Core 9 | Web framework |
| Entity Framework Core 9 | ORM |
| SQL Server | Database |
| FluentValidation | Request validation |
| xUnit | Automated testing |
| NSubstitute | Mocking for unit tests |

---

## Endpoints

| Method | Route | Description | Status |
|---|---|---|---|
| `POST` | `/tarefas` | Create task | `201 Created` |
| `GET` | `/tarefas` | List all tasks | `200 OK` |
| `PUT` | `/tarefas/{id}` | Edit task | `204 No Content` |
| `PATCH` | `/tarefas/{id}/concluir` | Complete task | `204 No Content` |
| `DELETE` | `/tarefas/{id}` | Delete task | `204 No Content` |

---

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local or Docker)

### Running locally

```bash
# 1. Clone the repository
git clone https://github.com/your-username/TaskManager.git
cd TaskManager

# 2. Set your connection string in TaskManager.API/appsettings.json
# "DefaultConnection": "Server=localhost;Database=TaskManagerDb;Trusted_Connection=True;TrustServerCertificate=True"

# 3. Run migrations
cd TaskManager.API
dotnet ef database update

# 4. Start the application
dotnet run
```

The API will be available at `http://localhost:5222`.

---

## Running Tests

```bash
# From the solution root
dotnet test
```

---

## Project Structure

```
TaskManager/
├── TaskManager.API/
│   ├── Domain/
│   │   ├── Entities/
│   │   │   └── Tarefa.cs
│   │   └── Interfaces/
│   │       └── ITarefaRepository.cs
│   ├── Application/
│   │   └── UseCases/
│   │       ├── CriarTarefa/
│   │       ├── ListarTarefas/
│   │       ├── EditarTarefa/
│   │       ├── ConcluirTarefa/
│   │       └── DeletarTarefa/
│   ├── Infrastructure/
│   │   └── Persistence/
│   │       ├── AppDbContext.cs
│   │       └── TarefaRepository.cs
│   └── Presentation/
│       ├── Controllers/
│       │   └── TarefaController.cs
│       └── Middlewares/
│           └── ExceptionMiddleware.cs
└── TaskManager.Tests/
    └── UseCases/
        ├── CriarTarefaUseCaseTests.cs
        └── ConcluirTarefaUseCaseTests.cs
```

---

## Architectural Decisions

**Why Clean Architecture?**
Isolates business rules from frameworks and databases. The Domain layer has zero knowledge of EF Core. The Application layer has zero knowledge of SQL Server. This makes testing easier and keeps the codebase maintainable as it grows.

**Why separate Use Cases?**
Each operation has a single responsibility. Each Use Case can be read, tested, and evolved independently without touching unrelated code.

**Why Repository Pattern?**
The Application layer depends on `ITarefaRepository` (interface), not `TarefaRepository` (implementation). This allows swapping the database or using in-memory fakes in tests without changing any Use Case.
