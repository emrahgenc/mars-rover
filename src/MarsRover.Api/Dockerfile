#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/MarsRover.Api/MarsRover.Api.csproj", "src/MarsRover.Api/"]
COPY ["src/MarsRover.Infrastructure/MarsRover.Infrastructure.csproj", "src/MarsRover.Infrastructure/"]
COPY ["src/MarsRover.Domain/MarsRover.Domain.csproj", "src/MarsRover.Domain/"]
COPY ["shared/MarsRover.Core.Abstraction/MarsRover.Core.Abstraction.csproj", "shared/MarsRover.Core.Abstraction/"]
COPY ["shared/MarsRover.Data.EntityFramework/MarsRover.Data.EntityFramework.csproj", "shared/MarsRover.Data.EntityFramework/"]
RUN dotnet restore "src/MarsRover.Api/MarsRover.Api.csproj"
COPY . .
WORKDIR "/src/src/MarsRover.Api"
RUN dotnet build "MarsRover.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarsRover.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarsRover.Api.dll"]