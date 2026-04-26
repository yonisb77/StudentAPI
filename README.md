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
StudentAPI/
├── 1. Domain/                  # Entiteter & Repository Interfaces
├── 2. Application/             # CQRS · Commands · Queries · Handlers
│   ├── Commands/               # SkapaKurs, UppdateraKurs, RaderaKurs
│   │                           # SkapaLarare, UppdateraLarare, RaderaLarare
│   ├── Queries/                # HamtaAllaKurser, HamtaKursViaId
│   │                           # HamtaAllaLarare, HamtaLarareViaId
│   └── Handlers/               # En handler per Command/Query
├── 3. Infrastructure/          # SkolaDbContext · EF Core · Repositories
└── 4. API/                     # Controllers · Program.cs · DI-konfiguration
```

---

## 🏗️ Arkitekturlager

| # | Lager | Ansvar | Innehåll |
|---|-------|--------|----------|
| 1 | **Domain** | Kärnlogik & entiteter | `Kurs`, `Larare` (1-till-många) och `IKursRepository`, `ILarareRepository` |
| 2 | **Application** | Use cases & CQRS | Commands, Queries och MediatR Handlers |
| 3 | **Infrastructure** | Dataåtkomst | `KursRepository`, `LarareRepository`, `SkolaDbContext`, EF Core migrationer |
| 4 | **API** | Presentation | `KursController`, `LarareController`, DI-registrering, Swagger-konfiguration |

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

| Metod | Endpoint | Beskrivning |
|-------|----------|-------------|
| `GET` | `/api/Kurs` | Hämtar samtliga kurser från databasen |
| `GET` | `/api/Kurs/{id}` | Hämtar detaljerad information om en specifik kurs |
| `POST` | `/api/Kurs` | Registrerar en ny kurs och kopplar den till en lärare |
| `PUT` | `/api/Kurs/{id}` | Uppdaterar information på en befintlig kurs |
| `DELETE` | `/api/Kurs/{id}` | Tar bort en kurs permanent från systemet |
| `GET` | `/api/Larare` | Hämtar samtliga lärare från databasen |
| `GET` | `/api/Larare/{id}` | Hämtar detaljerad information om en specifik lärare |
| `POST` | `/api/Larare` | Registrerar en ny lärare i systemet |
| `PUT` | `/api/Larare/{id}` | Uppdaterar information på en befintlig lärare |
| `DELETE` | `/api/Larare/{id}` | Tar bort en lärare permanent från systemet |


## 🚀 Kom igång

### Förutsättningar

- [x] .NET 9 SDK installerat
- [x] SQL Server (LocalDB eller SQLEXPRESS)

### Installation

**1. Klona repositoryt**

```bash
git clone https://github.com/yonisb77/StudentAPI.git
cd StudentAPI
```

**2. Kontrollera anslutningssträngen**

Öppna `API/appsettings.json` och verifiera att anslutningssträngen pekar mot din SQL Server-instans:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=StudentAPI;Trusted_Connection=True;"
}
```

**3. Kör migrationer**

Öppna **Package Manager Console**, sätt **Default project** till `Infrastructure` och kör:

```powershell
Update-Database -Project Infrastructure -StartupProject API
```

**4. Starta och testa**

Starta projektet och navigera till `/swagger` för att utforska och testa alla endpoints via Swagger UI.
