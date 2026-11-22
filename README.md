# VisiCartAPI

API REST desarrollada en **ASP.NET Core Web API** con **Dapper** y **SQL Server** (`VisiCartDB`), diseñada para gestionar las operaciones CRUD mediante procedimientos almacenados (`Stored Procedures`).

## Tecnologías utilizadas

* **Framework:** ASP.NET Core Web API
* **Acceso a datos:** Dapper + Microsoft.Data.SqlClient
* **Base de datos:** Microsoft SQL Server (`VisiCartDB`)
* **Pruebas de API:** Postman

## Estructura del proyecto

```text
VisiCartAPI/
├── Controllers/
│   ├── ClientesController.cs
│   └── ProductosController.cs
├── Data/
│   └── Connection.cs            # Namespace VisiCartAPI.Data (CreateConnection())
├── Models/
│   ├── Cliente.cs
│   └── Producto.cs
├── Repositories/
│   ├── ClienteRepository.cs
│   └── ProductoRepository.cs
├── Properties/
│   └── launchSettings.json      # Perfiles de ejecución (ej. https://localhost:7297)
└── Program.cs
