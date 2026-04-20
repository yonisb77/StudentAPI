# 🎓 StudentAPI

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet)
![Architecture](https://img.shields.io/badge/Architecture-Clean-brightgreen?style=for-the-badge)
![Pattern](https://img.shields.io/badge/Pattern-CQRS-blue?style=for-the-badge)
![ORM](https://img.shields.io/badge/ORM-Entity_Framework_Core-orange?style=for-the-badge)
![Docs](https://img.shields.io/badge/Docs-Swagger_UI-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

> Enterprise-redo Web API för hantering av **kurser och lärare**, byggt med .NET 9.  
> Följer strikt **Clean Architecture** och **CQRS-principer** för hög testbarhet, lösa kopplingar och en skalbar kodbas.

---

## 📂 Projektstruktur
```text
   ├── 1. Domain/                  # Entiteter & Repository Interfaces
   ├── 2. Application/             # CQRS · Commands · Queries · Handlers
   │   
   ├── 3. Infrastructure/          # SkolaDbContext · EF Core · Repositories
   └── 4. API/                     # Controllers · Program.cs · DI-konfiguration

```

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
| **ASP.NET Core Web API** | Ramverk — .NET 9 |
| **Entity Framework Core** | ORM, SQL Server, Code-First migrationer |
| **MediatR** | CQRS-implementation via Mediator-mönstret |
| **Swagger / OpenAPI** | Interaktiv API-dokumentation på `/swagger` |

### Designmönster
- **CQRS** — separation av läs- och skrivoperationer via MediatR
- **Repository Pattern** — abstraktion av databaslogiken
- **Dependency Injection** — Inversion of Control genomgående i alla lager

---

## 🚦 API Endpoints

Swagger UI är tillgängligt på `/swagger` vid körning.

### Queries — Läsoperationer

| Metod | Endpoint | Beskrivning |
|-------|----------|-------------|
| `GET` | `/api/Kurs/hamta-alla` | Hämtar samtliga kurser från databasen |
| `GET` | `/api/Kurs/hamta/{id}` | Hämtar detaljerad information om en specifik kurs |

### Commands — Skrivoperationer

| Metod | Endpoint | Beskrivning |
|-------|----------|-------------|
| `POST` | `/api/Kurs/skapa` | Registrerar en ny kurs och kopplar den till en lärare |
| `PUT` | `/api/Kurs/uppdatera` | Uppdaterar information på en befintlig kurs |
| `DELETE` | `/api/Kurs/radera/{id}` | Tar bort en kurs permanent från systemet |
