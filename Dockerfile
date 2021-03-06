# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY NewWorldAPI/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ./NewWorldAPI ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
# get the certificate
COPY --from=build-env /app/Properties ./Properties
ENTRYPOINT ["dotnet", "NewWorldAPI.dll"]
