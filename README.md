If not using VS (i.e. text editor like VS Code):

https://docs.microsoft.com/en-us/ef/core/cli/dotnet

```bash
dotnet tool install --global dotnet-ef
```

To add migration (from src directory):

```bash

```

To update database (from src directory):

```bash
dotnet ef database update --startup-project EFCoreEncapsulate.Api\ --project .\EFCoreEncapsulate.Data\
```

