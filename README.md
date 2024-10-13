# Football-League
## Run App with runApi.bat. You will need run docker engine before execute file.

## Open http://localhost:5000/swagger/index.html

## Stop App with stopApi.bat.

# Migrations:
## create 
dotnet ef migrations add <Migation-Name> --project ./Infrastructure/Infrastructure.csproj --startup-project  ./Startup/startup.csproj
## update db
dotnet ef database update --project ./Infrastructure/Infrastructure.csproj --startup-project  ./Startup/startup.csproj
