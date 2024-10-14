# Football-League
## Run App with runApi.bat. You will need run docker engine before execute file.

Note: Please read the commands! After docker compose is done will PAUSE. Press any key to continue and will execute migrations process (database update). 

## Open swagger http://localhost:5000/swagger/index.html
## Open MSSQL server UI http://localhost:8080/?mssql=mssql&username=sa
Note:   System: Use MS SQL 
        Server: mssql
        User: sa
        Password: YourStrong@Passw0rd


## Stop App with stopApi.bat.

<!-- # Migrations:
## create 
dotnet ef migrations add <Migation-Name> --project ./Infrastructure/Infrastructure.csproj --startup-project  ./Startup/startup.csproj
## update db
dotnet ef database update --project ./Infrastructure/Infrastructure.csproj --startup-project  ./Startup/startup.csproj -->
