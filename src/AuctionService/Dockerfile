# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80

# Copy the solution file and project files
COPY carsties.sln .
COPY src/AuctionService/AuctionService.csproj src/AuctionService/
COPY src/SearchService/SearchService.csproj src/SearchService/
COPY src/GatewayService/GatewayService.csproj src/GatewayService/
COPY src/Contracts/Contracts.csproj src/Contracts/
COPY src/IdentityService/IdentityService.csproj src/IdentityService/

# Restore the NuGet packages for all projects in the solution
RUN dotnet restore

# Copy the rest of the source code into the container
#COPY src/AuctionService src/AuctionService
#COPY src/Contracts src/Contracts
COPY . .

# Set the working directory to the AuctionService project directory
WORKDIR /app/src/AuctionService

# Build and publish the AuctionService project to the /app/out directory
RUN dotnet publish -c Release -o /app/out

# Use the ASP.NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published output from the build stage to the current working directory in the runtime image
COPY --from=build /app/out .

# Set the entry point for the container to run the AuctionService.dll using the dotnet command
ENTRYPOINT ["dotnet", "AuctionService.dll"]
