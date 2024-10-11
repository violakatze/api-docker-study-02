FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5296

ENV ASPNETCORE_URLS=http://*:5296

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["api-docker-study-02.csproj", "./"]
RUN dotnet restore "api-docker-study-02.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "api-docker-study-02.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet publish "api-docker-study-02.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM build AS migration
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet tool install --global dotnet-ef --version 8.0.10
ENTRYPOINT ["dotnet", "ef", "database", "update" ]

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api-docker-study-02.dll"]
