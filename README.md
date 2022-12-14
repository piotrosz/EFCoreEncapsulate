Experiments based on Pluralsight courses:

https://app.pluralsight.com/library/courses/ef-core-6-encapsulating-usage

https://app.pluralsight.com/library/courses/ef-core-6-best-practices/table-of-contents

https://app.pluralsight.com/library/courses/cqrs-in-practice/table-of-contents

Topics: ASP.NET Core, EF Core, CQRS, DDD

If not using VS (i.e. text editor like VS Code):

https://docs.microsoft.com/en-us/ef/core/cli/dotnet

```bash
dotnet tool install --global dotnet-ef
```

To add migration (from src directory):

```bash
dotnet ef migrations add student-data --startup-project EFCoreEncapsulate.Api\ --project .\EFCoreEncapsulate.Infrastructure\
```

To update database (from src directory):

```bash
dotnet ef database update --startup-project EFCoreEncapsulate.Api\ --project .\EFCoreEncapsulate.Infrastructure\
```

