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

Open a terminal to the parent directory and then run the below commands

```bash
dotnet test ApiTest.DataModule.Tests/ApiTest.DataModule.Tests.csproj
dotnet test ApiTest.WebApi.Tests/ApiTest.WebApi.Tests.csproj
```

Also included in the root of this repo is a postman colelction

### Running

Open a terminal to the parent directory and then run the below commands

```bash
dotnet build ApiTest.sln
dotnet run -p ApiTest.WebApi/ApiTest.Webapi.csproj
```

Using the localhost port provided in the terminal output, you can now use the API. (Using Swagger, Postman, or anything else of your choice).

## API list

1. Posts
     - *GET /api/post/{id}
	 - *PUT /api/post/{id}
	 - *DELETE /api/post/{id}
	 - *POST /api/post/

2. Users
     - *GET /api/user/{id}
	 - *PUT /api/user/{id}
	 - *DELETE /api/user/{id}
	 - *POST /api/user/

3. Albums
     - *GET /api/album/{id}
	 - *PUT /api/album/{id}
	 - *DELETE /api/album/{id}
	 - *POST /api/album/

4. Collections
     - *GET /api/collection
