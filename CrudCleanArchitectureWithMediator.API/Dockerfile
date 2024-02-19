#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CrudCleanArchitectureWithMediator.API/CrudCleanArchitectureWithMediator.API.csproj", "CrudCleanArchitectureWithMediator.API/"]
RUN dotnet restore "CrudCleanArchitectureWithMediator.API/CrudCleanArchitectureWithMediator.API.csproj"
COPY . .
WORKDIR "/src/CrudCleanArchitectureWithMediator.API"
RUN dotnet build "CrudCleanArchitectureWithMediator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CrudCleanArchitectureWithMediator.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CrudCleanArchitectureWithMediator.API.dll"]