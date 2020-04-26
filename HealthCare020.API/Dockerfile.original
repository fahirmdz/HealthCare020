#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["HealthCare020.API/HealthCare020.API.csproj", "HealthCare020.API/"]
RUN dotnet restore "HealthCare020.API/HealthCare020.API.csproj"
COPY . .
WORKDIR "/src/HealthCare020.API"
RUN dotnet build "HealthCare020.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HealthCare020.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthCare020.API.dll"]