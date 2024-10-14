
cd ./Footbal.League.Application/Footbal.League.API/src

docker-compose -f composeApiNdDb.yml up -d

pause

dotnet ef database update --project ./Infrastructure/Infrastructure.csproj --startup-project  ./Startup/startup.csproj