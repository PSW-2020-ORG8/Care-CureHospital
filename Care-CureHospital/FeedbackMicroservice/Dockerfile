FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FeedbackMicroservice/FeedbackMicroservice.csproj", "FeedbackMicroservice/"]
COPY ["EventSourcingMicroservice/EventSourcingMicroservice.csproj", "EventSourcingMicroservice/"]
RUN dotnet restore "FeedbackMicroservice/FeedbackMicroservice.csproj"
COPY . .
WORKDIR "/src/FeedbackMicroservice"
RUN dotnet build "FeedbackMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FeedbackMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeedbackMicroservice.dll"]