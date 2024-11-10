# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copiar los archivos del proyecto para cada capa y restaurar las dependencias
COPY ["API/API.csproj", "API/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]

# Restaurar las dependencias
RUN dotnet restore "API/API.csproj"

# Copiar el resto de los archivos y construir la aplicación
COPY . .
RUN dotnet build "API/API.csproj" -c Release -o /app/build

# Publicar la aplicación
RUN dotnet publish "API/API.csproj" -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Exponer el puerto 8080
EXPOSE 8080

# Configurar la aplicación para que escuche en el puerto 8080
ENV ASPNETCORE_URLS=http://+:8080

# Punto de entrada
ENTRYPOINT ["dotnet", "API.dll"]
