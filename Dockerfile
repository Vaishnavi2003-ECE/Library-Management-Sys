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

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# copy published output from build stage
COPY --from=build /app/publish .

# Run the app
ENTRYPOINT ["dotnet", "LabraryManagement.dll"]
