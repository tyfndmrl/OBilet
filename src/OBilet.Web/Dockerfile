#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/OBilet.Web/OBilet.Web.csproj", "src/OBilet.Web/"]
COPY ["src/OBilet.Application/OBilet.Application.csproj", "src/OBilet.Application/"]
COPY ["src/OBilet.Domain/OBilet.Domain.csproj", "src/OBilet.Domain/"]
RUN dotnet restore "./src/OBilet.Web/OBilet.Web.csproj"
COPY . .
WORKDIR "/src/src/OBilet.Web"
RUN dotnet build "./OBilet.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OBilet.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OBilet.Web.dll"]