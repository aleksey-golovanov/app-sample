# Usage

Publish database from AppSample.Db, set correct connection string in appsettings.json, then use .NET Core CLI

```
dotnet publish <PROJECT> -o|--output <OUTPUT_DIRECTORY>
cd <OUTPUT_DIRECTORY>
dotnet AppSample.WebUI.dll
```