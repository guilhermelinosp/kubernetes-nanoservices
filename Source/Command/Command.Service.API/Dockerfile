FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Source/Command/Command.Service.API/Command.Service.API.csproj", "Source/Command/Command.Service.API/"]
COPY ["Source/Command/Command.Service.Infrastructure/Command.Service.Infrastructure.csproj", "Source/Command/Command.Service.Infrastructure/"]
COPY ["Source/Command/Command.Service.Application/Command.Service.Application.csproj", "Source/Command/Command.Service.Application/"]
COPY ["Source/Command/Command.Service.Domain/Command.Service.Domain.csproj", "Source/Command/Command.Service.Domain/"]

RUN dotnet restore "Source/Command/Command.Service.API/Command.Service.API.csproj"

COPY . .
WORKDIR "/src/Source/Command/Command.Service.API"
RUN dotnet build "Command.Service.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Command.Service.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Command.Service.API.dll"]
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 CMD curl --silent --fail http://localhost:80/health || exit 1

