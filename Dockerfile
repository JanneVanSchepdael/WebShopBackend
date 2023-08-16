FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 80

ENV DOTNET_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["WebShopAPI.sln", "./"]
COPY ["WebShopAPI/API.csproj", "WebShopAPI/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Repositories/Repositories.csproj", "Repositories/"]
COPY ["Persistence/Persistence.csproj", "Persistence/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore

# Copy the main source project files
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebShopAPI/API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebShopAPI/API.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "API.dll"]