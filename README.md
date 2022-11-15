# C# .NET ApiTest

This is an example webapi from scratch including full CRUD functionalities, testing and using an external data source.

## Installation

Requires [NET 5.0 CLI](https://dotnet.microsoft.com/download) or later

Requires Newtonsoft.Json

```bash
Install-Package Newtonsoft.Json
```

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

Then go to the [Swagger UI](http://localhost:5143/swagger/index.html) in any browser (you may need to adjust the port number as shown in your terminal output)
