# Football-League

# Migrations:
## create 
dotnet ef migrations add <Migation-Name> --project ./Infrastructure/Infrastructure.csproj --startup-project  ./Startup/startup.csproj
## update db
dotnet ef database update --project ./Infrastructure/Infrastructure.csproj --startup-project  ./Startup/startup.csproj
