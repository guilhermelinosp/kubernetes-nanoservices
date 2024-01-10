FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Source/Command/Command.Service.API/Command.Service.API.csproj", "Source/Command/Command.Service.API/"]
COPY ["Source/Command/Command.Service.Application/Command.Service.Application.csproj", "Source/Command/Command.Service.Application/"]
COPY ["Source/Command/Command.Service.Domain/Command.Service.Domain.csproj", "Source/Command/Command.Service.Domain/"]
COPY ["Source/Command/Command.Service.Infrastructure/Command.Service.Infrastructure.csproj", "Source/Command/Command.Service.Infrastructure/"]
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
