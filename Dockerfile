# Dockerfile básico para la API
# ⚠️ Este Dockerfile funciona pero tiene áreas de mejora (ver README sección Docker)

FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-chiseled-extra AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copiar archivos de proyecto (.csproj) individualmente
# Esto se hace PRIMERO para que el 'dotnet restore' se cachee
COPY ["CleanArchitecture.PracticalTest.API/CleanArchitecture.PracticalTest.API.csproj", "CleanArchitecture.PracticalTest.API/"]
COPY ["CleanArchitecture.PracticalTest.Application/CleanArchitecture.PracticalTest.Application.csproj", "CleanArchitecture.PracticalTest.Application/"]
COPY ["CleanArchitecture.PracticalTest.Domain/CleanArchitecture.PracticalTest.Domain.csproj", "CleanArchitecture.PracticalTest.Domain/"]
COPY ["CleanArchitecture.PracticalTest.Infrastructure/CleanArchitecture.PracticalTest.Infrastructure.csproj", "CleanArchitecture.PracticalTest.Infrastructure/"]

RUN dotnet restore "CleanArchitecture.PracticalTest.API/CleanArchitecture.PracticalTest.API.csproj"

COPY . .
WORKDIR /src/CleanArchitecture.PracticalTest.API
RUN dotnet build "CleanArchitecture.PracticalTest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENTRYPOINT ["dotnet", "CleanArchitecture.PracticalTest.API.dll"]