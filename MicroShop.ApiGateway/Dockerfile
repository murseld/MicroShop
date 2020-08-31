#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MicroShop.ApiGateway/MicroShop.ApiGateway.csproj", "MicroShop.ApiGateway/"]
COPY ["MicroShop.Core/MicroShop.Core.csproj", "MicroShop.Core/"]
RUN dotnet restore "MicroShop.ApiGateway/MicroShop.ApiGateway.csproj"
COPY . .
WORKDIR "/src/MicroShop.ApiGateway"
RUN dotnet build "MicroShop.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroShop.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroShop.ApiGateway.dll"]