# BookSearch

A small C# / .NET 10 project for searching a catalogue of books, built in two phases:

| Project | Type | What it does |
|---|---|---|
| **BookSearchApp** | Console app (Phase 1) | Interactive menu to search books by name or look one up by ID |
| **BookSearchApi** | ASP.NET Core Web API (Phase 2) | The same search features exposed as REST endpoints, with Swagger UI |

Both projects use a hard-coded, in-memory list of books, so there's no database to set up.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Getting started

```bash
git clone https://github.com/ThobiMalinga/BookSearch.git
cd BookSearch
dotnet build
```

## BookSearchApp (console)

```bash
dotnet run --project BookSearchApp
```

You'll see a menu:

```
Choose an option:
1. Search book by name
2. Get book by ID
3. Exit
```

- **Search by name** does a partial, case-insensitive match, so `clean` finds *Clean Code*.
- **Get by ID** checks the input and gives a clear message for empty input, non-numbers, or IDs that don't exist.

## BookSearchApi (Web API)

```bash
dotnet run --project BookSearchApi
```

The API runs at `http://localhost:5087`. In development, Swagger UI is available at
**http://localhost:5087/swagger** for trying the endpoints in the browser.

### Endpoints

| Method | Route | Description | Responses |
|---|---|---|---|
| `GET` | `/api/books/search?name={term}` | Search books by partial, case-insensitive name | `200` list of books · `400` no name given · `404` no matches |
| `GET` | `/api/books/{id}` | Get a single book by ID | `200` book · `404` not found |

### Example

```bash
curl "http://localhost:5087/api/books/search?name=clean"
```

```json
[
  {
    "id": 1,
    "name": "Clean Code",
    "description": "A handbook of agile software craftsmanship",
    "publishedDate": "2008-08-01T00:00:00"
  }
]
```

## Project structure

Both projects follow the same layered design. Each layer has one job, and depends on the layer below through an interface:

```
Controller / Program.cs   →  handles input and output (HTTP or console)
        ↓
Service                   →  business logic (search, validation)
        ↓
Repository                →  data access (currently an in-memory list)
```

```
BookSearch/
├── BookSearch.slnx
├── BookSearchApp/               # Phase 1: console app
│   ├── Models/                  # Book entity
│   ├── Repositories/            # IBookRepository + in-memory data
│   ├── Services/                # IBookService, BookLookupResult
│   └── Program.cs               # Menu loop
└── BookSearchApi/               # Phase 2: Web API
    ├── Controllers/             # BooksController (HTTP endpoints)
    ├── DTOs/                    # BookDto (the API response shape)
    ├── Mappers/                 # Book → BookDto mapping
    ├── Models/                  # Book entity
    ├── Repositories/            # IBookRepository + in-memory data
    ├── Services/                # IBookService (business logic)
    └── Program.cs               # DI registration, Swagger, routing
```

The API adds a few things on top of the console app:

- **Dependency injection.** The repository and service are registered in `Program.cs`, not created by hand.
- **DTOs and mappers.** The internal `Book` model stays separate from what the API returns, so one can change without breaking the other.
- **Thin controllers.** The controller only handles HTTP concerns (status codes, mapping). The service holds the logic.

## Sample data

| ID | Name | Published |
|---|---|---|
| 1 | Clean Code | 2008-08-01 |
| 2 | The Pragmatic Programmer | 1999-10-20 |
| 3 | C# in Depth | 2019-03-23 |
