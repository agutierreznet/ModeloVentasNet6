#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sales.WebApi/Sales.WebApi.csproj", "Sales.WebApi/"]
COPY ["Sales.ApplicationCore/Sales.ApplicationCore.csproj", "Sales.ApplicationCore/"]
COPY ["Sales.Infrastructure/Sales.Infrastructure.csproj", "Sales.Infrastructure/"]
RUN dotnet restore "Sales.WebApi/Sales.WebApi.csproj"
COPY . .
WORKDIR "/src/Sales.WebApi"
RUN dotnet build "Sales.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sales.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sales.WebApi.dll"]