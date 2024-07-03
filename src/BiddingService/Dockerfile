# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80

# Copy the solution file and project files
COPY carsties.sln carsties.sln
COPY src/AuctionService/AuctionService.csproj src/AuctionService/AuctionService.csproj
COPY src/SearchService/SearchService.csproj src/SearchService/SearchService.csproj
COPY src/GatewayService/GatewayService.csproj src/GatewayService/GatewayService.csproj
COPY src/BiddingService/BiddingService.csproj src/BiddingService/BiddingService.csproj
COPY src/Contracts/Contracts.csproj src/Contracts/Contracts.csproj
COPY src/IdentityService/IdentityService.csproj src/IdentityService/IdentityService.csproj

# Restore the NuGet packages for all projects in the solution
RUN dotnet restore carsties.sln

# Copy the rest of the source code into the container
COPY src/BiddingService src/BiddingService
COPY src/Contracts src/Contracts

# Set the working directory to the BiddingService project directory
WORKDIR /app/src/BiddingService

# Build and publish the BiddingService project to the /app/out directory
RUN dotnet publish -c Release -o /app/src/out

# Use the ASP.NET runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published output from the build stage to the current working directory in the runtime image
COPY --from=build /app/src/out .

# Set the entry point for the container to run the BiddingService.dll using the dotnet command
ENTRYPOINT ["dotnet", "BiddingService.dll"]
