docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=MyComplexPassword!234' -p 1433:1433 -d microsoft/mssql-server-linux
dotnet ef database update
dotnet run