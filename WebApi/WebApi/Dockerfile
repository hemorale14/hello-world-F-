#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Construir imagen y cargar la aplicación
#docker build -f "WebApi\Dockerfile" -t hemorale14/fsharp-web-api:1.0.0 .
# Enviar la imagen a un repositorio público de Docker Hub
#docker push hemorale14/fsharp-web-api:1.0.0
# Levantar la aplicación y hacer port-forwarding para visualizar la API en local sobre el puerto 9003
#docker run --name my-fsharp-web-api -dp 9003:8080 hemorale14/fsharp-web-api:1.0.0

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebApi/WebApi.fsproj", "WebApi/"]
RUN dotnet restore "./WebApi/./WebApi.fsproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "./WebApi.fsproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApi.fsproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]