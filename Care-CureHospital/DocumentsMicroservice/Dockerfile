FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DocumentsMicroservice/DocumentsMicroservice.csproj", "DocumentsMicroservice/"]
COPY ["EventSourcingMicroservice/EventSourcingMicroservice.csproj", "EventSourcingMicroservice/"]
RUN dotnet restore "DocumentsMicroservice/DocumentsMicroservice.csproj"
COPY . .
WORKDIR "/src/DocumentsMicroservice"
RUN dotnet build "DocumentsMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DocumentsMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet   DocumentsMicroservice.dll