FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BestMoviesApp/BestMoviesApp.csproj", "BestMoviesApp/"]
RUN dotnet restore "BestMoviesApp/BestMoviesApp.csproj"
COPY . .
WORKDIR "/src/BestMoviesApp"
RUN dotnet build "BestMoviesApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BestMoviesApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BestMoviesApp.dll"]
