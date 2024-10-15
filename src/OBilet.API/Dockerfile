#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/OBilet.API/OBilet.API.csproj", "src/OBilet.API/"]
COPY ["src/OBilet.Application/OBilet.Application.csproj", "src/OBilet.Application/"]
COPY ["src/OBilet.Domain/OBilet.Domain.csproj", "src/OBilet.Domain/"]
COPY ["src/OBilet.Infrastructure/OBilet.Infrastructure.csproj", "src/OBilet.Infrastructure/"]
RUN dotnet restore "./src/OBilet.API/OBilet.API.csproj"
COPY . .
WORKDIR "/src/src/OBilet.API"
RUN dotnet build "./OBilet.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OBilet.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OBilet.API.dll"]