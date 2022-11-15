# C# .NET ApiTest

This is an example webapi from scratch including full CRUD functionalities, testing and using an external data source.

## Installation

Requires [NET 5.0 CLI](https://dotnet.microsoft.com/download) or later

## Usage

### Testing

Open a terminal to the parent directory and then run the below command

```bash
dotnet test ApiTest.DataModule.Tests/ApiTest.DataModule.Tests.csproj
```

### Running

Open a terminal to the parent directory and then run the below commands

```bash
dotnet build ApiTest.sln
dotnet run -p ApiTest.WebApi/ApiTest.Webapi.csproj
```