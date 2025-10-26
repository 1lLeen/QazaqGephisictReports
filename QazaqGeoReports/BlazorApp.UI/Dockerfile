# ===== build =====
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
# путь к csproj из КОНТЕКСТА: ./BlazorApp.UI/BlazorApp.UI.csproj
RUN dotnet restore ./BlazorApp.UI/BlazorApp.UI.csproj
RUN dotnet publish ./BlazorApp.UI/BlazorApp.UI.csproj -c Release -o /app/publish

# ===== runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
ENTRYPOINT ["dotnet","BlazorApp.UI.dll"]
