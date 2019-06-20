FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 8081

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY FC.SC.AccountManager.sln ./
COPY FC.SC.AccountManager.API/FC.SC.AccountManager.API.csproj FC.SC.AccountManager.API/
COPY FC.SC.AccountManager.Platform/FC.SC.AccountManager.Platform.csproj FC.SC.AccountManager.Platform/
COPY FC.SC.AccountManager.Repository/FC.SC.AccountManager.Repository.csproj FC.SC.AccountManager.Repository/
COPY docker-compose.dcproj ./
RUN dotnet restore FC.SC.AccountManager.API/FC.SC.AccountManager.API.csproj
COPY . .
WORKDIR /src/FC.SC.AccountManager.API
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FC.SC.AccountManager.API.dll"]
