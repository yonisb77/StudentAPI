# 🎓 StudentAPI

Enterprise-redo Web API för hantering av kurser och lärare, byggt med **.NET 9**.  
Följer strikt **Clean Architecture** och **CQRS**-principer för hög testbarhet, lösa kopplingar och en skalbar kodbas.

---

## 📂 Projektstruktur

```
StudentAPI/
├── 1. Domain/               # Entiteter & Repository Interfaces
├── 2. Application/          # CQRS · Commands · Queries · Handlers
├── 3. Infrastructure/       # SkolaDbContext · EF Core · Repositories
└── 4. API/                  # Controllers · Program.cs · DI-konfiguration
```

> Beroenden pekar alltid inåt mot Domain-lagret.

---

## 🏗️ Arkitekturlager

| # | Lager | Ansvar | Innehåll |
|---|-------|--------|----------|
| 1 | **Domain** | Kärnlogik & entiteter | `Kurs`, `Larare` (1-till-många) och `IKursRepository` |
| 2 | **Application** | Use cases & CQRS | Commands, Queries och MediatR Handlers |
| 3 | **Infrastructure** | Dataåtkomst | `KursRepository`, `SkolaDbContext`, EF Core migrationer |
| 4 | **API** | Presentation | `KursController`, DI-registrering, Swagger-konfiguration |

---

## 🛠️ Teknikstack

| Teknologi | Användning |
|-----------|------------|
| ASP.NET Core Web API | Ramverk — .NET 9 |
| Entity Framework Core | ORM, SQL Server, Code-First migrationer |
| MediatR | CQRS-implementation via Mediator-mönstret |
| Swagger / OpenAPI | Interaktiv API-dokumentation på `/swagger` |

---

## 🎨 Designmönster

- **CQRS** — separation av läs- och skrivoperationer via MediatR
- **Repository Pattern** — abstraktion av databaslogiken
- **Dependency Injection** — Inversion of Control genomgående i alla lager

---

## 🚦 API Endpoints

Swagger UI är tillgängligt på `/swagger` vid körning.

| `GET` | `/api/Kurs/hamta-alla` | Hämtar samtliga kurser från databasen |
| `GET` | `/api/Kurs/{id}` | Hämtar detaljerad information om en specifik kurs |
| `POST` | `/api/Kurs/skapa` | Registrerar en ny kurs och kopplar den till en lärare |
| `PUT` | `/api/Kurs/{id}` | Uppdaterar information på en befintlig kurs |
| `DELETE` | `/api/Kurs/{id}` | Tar bort en kurs permanent från systemet |
| `GET` | `/api/Larare/hamta-alla` | Hämtar samtliga lärare från databasen |
| `GET` | `/api/Larare/{id}` | Hämtar detaljerad information om en specifik lärare |
| `POST` | `/api/Larare/skapa` | Registrerar en ny lärare i systemet |
| `PUT` | `/api/Larare/{id}` | Uppdaterar information på en befintlig lärare |
| `DELETE` | `/api/Larare/{id}` | Tar bort en lärare permanent från systemet |

---

## ⚡ Kom igång

### Förutsättningar
- .NET 9 SDK
- SQL Server eller SQL Express

### Installation

```bash
# Klona repot
git clone https://github.com/yonisb77/StudentAPI.git
cd StudentAPI

# Uppdatera connection string i appsettings.json
# "DefaultConnection": "Server=...;Database=StudentAPI;..."

# Kör migrationer
dotnet ef database update --project Infrastructure

# Starta API:et
dotnet run --project API
```

Öppna sedan `https://localhost:{port}/swagger` för att testa API:et.
