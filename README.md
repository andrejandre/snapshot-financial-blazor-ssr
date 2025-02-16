# Snapshot Financial - Blazor SSR

Snapshot Financial is a Blazor Server-Side Rendering (SSR) web application for tracking and managing net worth. It is primitive. It demonstrates CRUD operations, pagination, and database persistence using SQLite and Entity Framework Core.

## Features
- **Blazor SSR Architecture** - Interactive UI with real-time updates.
- **Radzen UI Components** - Modern UI with data grids and dialogs.
- **SQLite Database** - Persistent storage with EF Core.
- **CRUD Operations** - Add, edit, delete financial records.
- **Pagination & Sorting** - Handles large datasets efficiently.
- **Toast Notifications** - Feedback on operations.

## Setup & Installation

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQLite](https://www.sqlite.org/download.html) (Optional)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code

### Steps
```sh
git clone https://github.com/andrejandre/snapshot-financial-blazor-ssr.git
cd snapshot-financial-blazor-ssr
dotnet restore
dotnet ef database update
dotnet run
visit http://localhost:xxxx or https://localhost:yyyyy
```
## Usage
- Add Record - Click "Add New Record", fill out details, and submit.
- Edit Record - Click the edit button, modify fields, and save.
- Delete Record - Click delete, confirm the action.

## License
This project is licensed under the MIT License.
