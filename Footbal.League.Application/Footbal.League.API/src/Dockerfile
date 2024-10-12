FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build 
WORKDIR /src
COPY ["./Startup/Startup.csproj", "./Startup/"]
COPY ["./API/API.csproj", "./API/"]
COPY ["./Application/Application.csproj", "./Application/"]
COPY ["./Domain/Domain.csproj", "./Domain/"]
COPY ["./Infrastructure/Infrastructure.csproj", "./Infrastructure/"]

RUN dotnet restore "./Startup/Startup.csproj"
COPY . .

WORKDIR "/src/Startup"
RUN ls -R /src > /src_contents.txt
RUN dotnet build "Startup.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Startup.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Startup.dll"]