# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TravelBlogs.Presentation/TravelBlogs.Presentation.Host/TravelBlogs.Presentation.Host.csproj", "src/TravelBlogs.Presentation/TravelBlogs.Presentation.Host/"]
COPY ["src/TravelBlogs.Infrastructure/TravelBlogs.Infrastructure.Migrators/TravelBlogs.Infrastructure.Migrators.csproj", "src/TravelBlogs.Infrastructure/TravelBlogs.Infrastructure.Migrators/"]
COPY ["src/TravelBlogs.Infrastructure/TravelBlogs.Infrastructure.Persistences/TravelBlogs.Infrastructure.Persistences.csproj", "src/TravelBlogs.Infrastructure/TravelBlogs.Infrastructure.Persistences/"]
COPY ["src/TravelBlogs.Core/TravelBlogs.Core.Application/TravelBlogs.Core.Application.csproj", "src/TravelBlogs.Core/TravelBlogs.Core.Application/"]
COPY ["src/TravelBlogs.Core/TravelBlogs.Core.Domain/TravelBlogs.Core.Domain.csproj", "src/TravelBlogs.Core/TravelBlogs.Core.Domain/"]
COPY ["src/TravelBlogs.Core/TravelBlogs.Core.Shared/TravelBlogs.Core.Shared.csproj", "src/TravelBlogs.Core/TravelBlogs.Core.Shared/"]
COPY ["src/TravelBlogs.Infrastructure/TravelBlogs.Infrastructure/TravelBlogs.Infrastructure.csproj", "src/TravelBlogs.Infrastructure/TravelBlogs.Infrastructure/"]
COPY ["src/TravelBlogs.Infrastructure/TravelBlogs.Infrastructure.ExternalService/TravelBlogs.Infrastructure.ExternalService.csproj", "src/TravelBlogs.Infrastructure/TravelBlogs.Infrastructure.ExternalService/"]
RUN dotnet restore "./src/TravelBlogs.Presentation/TravelBlogs.Presentation.Host/TravelBlogs.Presentation.Host.csproj"
COPY . .
WORKDIR "/src/src/TravelBlogs.Presentation/TravelBlogs.Presentation.Host"
RUN dotnet build "./TravelBlogs.Presentation.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TravelBlogs.Presentation.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelBlogs.Presentation.Host.dll"]