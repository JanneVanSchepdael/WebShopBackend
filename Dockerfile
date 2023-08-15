# Use the appropriate .NET SDK version as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Set the working directory inside the container
WORKDIR /app

# Copy the .csproj files and restore any dependencies (via dotnet restore)
COPY *.sln .
COPY WebShopAPI/API.csproj WebShopAPI/
COPY Domain/Domain.csproj Domain/
COPY Repositories/Repositories.csproj Repositories/
COPY Persistence/Persistence.csproj Persistence/
COPY Shared/Shared.csproj Shared/
RUN dotnet restore

# Copy the main source project files
COPY . ./

# Publish the API project
WORKDIR /app/WebShopAPI
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app
COPY --from=build-env /app/WebShopAPI/out .

# Specify the entry point of your app. Adjust accordingly if your main project has a different output DLL name
ENTRYPOINT ["dotnet", "API.dll"]