# natwarehouse - Warehouse management application

ASP.NET Core web application with Angular frontend. Application developed and tested on macOS.

## Prerequisites
- .NET Core 2.1
- npm
- Angular CLI
- MS SQL
- Docker (on macOS)

## Instructions

### Start MS SQL Docker image
This is needed on macOS, on Windows the default MS SQL Server should work by default
- sudo docker pull microsoft/mssql-server-linux:2017-latest
- sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=SecretPass0!' -p 1433:1433 --name mssql -d microsoft/mssql-server-linux:2017-latest
- docker start mssql

### Build and run backend
Easiest way is to run from Visual Studio, or run with dotnet CLI commands:
- cd NatWarehouse
- dotnet build
- dotnet run

### Start client application
Use Angular CLI to start the development server:
- cd NatWarehouseClient
- ng serve
- Open http://localhost:4200
