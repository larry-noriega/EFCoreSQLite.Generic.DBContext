
# EFCoreSQLite.Generic.DBContext

An ASP.NET Core web App against a SQLite database using EFCore with a Generic DBContext and a side DB integration with a generic repository pattern as well.

## Requirements

1. Use [Visual Studio Community](https://visualstudio.microsoft.com/es/vs/community/)
2. Use [DB Browser for SQLite](https://sqlitebrowser.org/dl/) to inspect the database.
3. Execute the solution file `.sln`

## How to use it?

Before execute with `F5`, add a breakpoint where is indicated go to
Tools > NuGet Package Manager > Package Manager Console and execute:

`> add-migration InitialMigration`

Fix EFCore auto-generated Bug in migration files:

![image](https://github.com/larry-noriega/EFCoreSQLite.Generic.DBContext/assets/4468105/2f7feb61-6f97-43ca-937e-9351d842871c)

`> Update-Database`

**That's it!**

<sub>Further information - Microsoft Docs:</sub>
- <sub>[Design-time DbContext Creation](https://learn.microsoft.com/en-gb/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli)</sub>
- <sub>[Working with DbContext](https://learn.microsoft.com/en-gb/ef/ef6/fundamentals/working-with-dbcontext)</sub>
- <sub>[Reflection & Attributes](https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/reflection-and-attributes/)</sub>
- <sub>Entity API:</sub>
	- <sub>[EntityTypeBuilder&#60;TEntity&#62; Class](https://learn.microsoft.com/en-gb/ef/ef6/fundamentals/working-with-dbcontext)</sub>


<sub>***So sorry about VSCode users...***</sub>
