FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["IntegrationTests/IntegrationTests.csproj", "IntegrationTests/"]
COPY ["WebAppPatient/WebAppPatient.csproj", "WebAppPatient/"]
COPY ["Backend/Backend.csproj", "Backend/"]
COPY ["IntegrationAdapters/IntegrationAdapters.csproj", "IntegrationAdapters/"]
RUN dotnet restore "IntegrationTests/IntegrationTests.csproj"
COPY . .
WORKDIR "/src/IntegrationTests"
RUN dotnet build "IntegrationTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IntegrationTests.csproj" -c Release -o /app/publish

FROM build AS test
WORKDIR /app
COPY --from=publish /app/publish .
CMD dotnet test IntegrationTests.dll