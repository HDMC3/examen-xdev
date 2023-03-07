# Como ejecutar el proyecto

\- Clonar y restaurar los paquetes

1. `git clone https://github.com/HDMC3/examen-xdev.git`
2. `cd examen-xdev`
3. `dotnet restore`

\- Restaurar las herramientas

4. `dotnet tool restore`

\- Agregar y aplicar una migración para la creación de la base de datos.

> Para este paso se debe establecer una cadena de conexion válida de SQL Server en la propiedad `ProductsAppContext` del archivo `appsettings.json`. 

5. `dotnet dotnet-ef migrations add Initial`
6. `dotnet dotnet-ef database update`

\- Ejecutar el proyecto:

7. `dotnet run`


# Tecnologías

### Frameworks y librerías

- [.NET 6](https://docs.microsoft.com/es-mx/dotnet/fundamentals/)
- [ClosedXML](https://github.com/ClosedXML/ClosedXML)

### Bases de datos

- SQL Server Developer 2022
- [Entity Framework](https://learn.microsoft.com/es-mx/ef/core/)
