# build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore ./QazaqGeoReports/BlazorApp.UI/BlazorApp.UI.csproj
RUN dotnet publish ./QazaqGeoReports/BlazorApp.UI/BlazorApp.UI.csproj -c Release -o /app/publish

# runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
EXPOSE 8080
ENTRYPOINT ["dotnet","BlazorApp.UI.dll"]
