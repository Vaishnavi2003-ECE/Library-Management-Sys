<<<<<<< HEAD
# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the csproj and restore
COPY LabraryManagement.csproj .
RUN dotnet restore LabraryManagement.csproj

# Copy the rest of the source
COPY . .

# Publish to /app/publish
RUN dotnet publish LabraryManagement.csproj -c Release -o /app/publish

=======
# Use the official ASP.NET runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Copy the .csproj and restore 
COPY LabraryManagement.csproj .
RUN dotnet restore LabraryManagement.csproj

# copy the rest of the source
COPY . .

# publish to /app/publish
RUN dotnet publish LabraryManagement.csproj -c Release -o /app/publish

>>>>>>> 0e64a995f6614948722a710e1255cca72af19325
# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

<<<<<<< HEAD
# Copy published output from build stage
=======
# copy published output from build stage
>>>>>>> 0e64a995f6614948722a710e1255cca72af19325
COPY --from=build /app/publish .

# Run the app
ENTRYPOINT ["dotnet", "LabraryManagement.dll"]
<<<<<<< HEAD

=======
>>>>>>> 0e64a995f6614948722a710e1255cca72af19325
