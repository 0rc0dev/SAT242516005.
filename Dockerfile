FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SAT242516005.csproj", "."]
RUN dotnet restore "./SAT242516005.csproj"
COPY . .
RUN dotnet build "SAT242516005.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SAT242516005.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SAT242516005.dll"]