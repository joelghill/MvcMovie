# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
    
# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore

RUN dotnet tool install --global dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools

RUN dotnet ef database update

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
COPY --from=build-env /app/movies.db .


ENTRYPOINT ["dotnet", "MvcMovie.dll"]

