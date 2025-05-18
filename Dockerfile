# Etapa 1: Imagen base para correr la app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Etapa 2: Imagen para construir la app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar los archivos del proyecto
COPY . .

# Restaurar dependencias (acá especificamos el proyecto correcto)
RUN dotnet restore ./BeIceProyect.Server/BeIceProyect.Server.csproj

# Compilar el proyecto en modo Release
RUN dotnet build ./BeIceProyect.Server/BeIceProyect.Server.csproj -c Release -o /app/build

# Publicar el proyecto para producción
RUN dotnet publish ./BeIceProyect.Server/BeIceProyect.Server.csproj -c Release -o /app/publish

# Etapa final: construir imagen liviana para correr
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BeIceProyect.Server.dll"]
