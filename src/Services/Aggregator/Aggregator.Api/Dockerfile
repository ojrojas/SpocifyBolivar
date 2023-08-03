#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Aggregator/Aggregator.Api/Aggregator.Api.csproj", "src/Services/Aggregator/Aggregator.Api/"]
RUN dotnet restore "src/Services/Aggregator/Aggregator.Api/Aggregator.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Aggregator/Aggregator.Api"
RUN dotnet build "Aggregator.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aggregator.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aggregator.Api.dll"]
