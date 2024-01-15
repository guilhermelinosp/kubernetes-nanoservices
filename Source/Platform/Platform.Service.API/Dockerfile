FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Source/Platform/Platform.Service.API/Platform.Service.API.csproj", "Source/Platform/Platform.Service.API/"]
COPY ["Source/Platform/Platform.Service.Infrastructure/Platform.Service.Infrastructure.csproj", "Source/Platform/Platform.Service.Infrastructure/"]
COPY ["Source/Platform/Platform.Service.Domain/Platform.Service.Domain.csproj", "Source/Platform/Platform.Service.Domain/"]
COPY ["Source/Platform/Platform.Service.Application/Platform.Service.Application.csproj", "Source/Platform/Platform.Service.Application/"]
RUN dotnet restore "Source/Platform/Platform.Service.API/Platform.Service.API.csproj"
COPY . .
WORKDIR "/src/Source/Platform/Platform.Service.API"
RUN dotnet build "Platform.Service.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Platform.Service.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Set metadata labels
LABEL version="1.0" \
      maintainer="Guilherme Lino <guilhermelinosp@gmail.com>"

# health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 CMD curl --silent --fail http://localhost:80/health || exit 1

# entrypoint
ENTRYPOINT ["dotnet", "Platform.Service.API.dll"]