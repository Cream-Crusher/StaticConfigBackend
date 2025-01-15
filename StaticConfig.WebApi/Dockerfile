FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StaticConfig.Application/StaticConfig.Application.csproj", "StaticConfig.Application.csproj"]
COPY ["StaticConfig.Domain/StaticConfig.Domain.csproj", "StaticConfig.Domain.csproj"]
COPY ["StaticConfig.Persistence/StaticConfig.Persistence.csproj", "StaticConfig.Persistence.csproj"]
COPY ["StaticConfig.WebApi/StaticConfig.WebApi.csproj", "StaticConfig.WebApi.csproj"]
RUN dotnet restore "StaticConfig.WebApi.csproj"
COPY . .
WORKDIR "/src/StaticConfig.WebApi"
RUN dotnet build StaticConfig.WebApi.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish StaticConfig.WebApi.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StaticConfig.WebApi.dll"]
