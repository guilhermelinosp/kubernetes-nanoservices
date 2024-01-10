FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443

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

# Set metadata labels
LABEL version="1.0" \
      maintainer="Guilherme Lino <guilhermelinosp@gmail.com>"

# health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 CMD curl --silent --fail http://localhost:80/health || exit 1

# entrypoint
ENTRYPOINT ["dotnet", "Command.Service.API.dll"]

