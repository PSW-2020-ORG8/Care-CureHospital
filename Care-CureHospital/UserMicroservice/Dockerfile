FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["UserMicroservice/UserMicroservice.csproj", "UserMicroservice/"]
COPY ["EventSourcingMicroservice/EventSourcingMicroservice.csproj", "EventSourcingMicroservice/"]
RUN dotnet restore "UserMicroservice/UserMicroservice.csproj"
COPY . .
WORKDIR "/src/UserMicroservice"
RUN dotnet build "UserMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet UserMicroservice.dll