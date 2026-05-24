FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /app

COPY . .

RUN dotnet restore
RUN dotnet publish ./ClyvoVet.Api/ClyvoVet.Api.csproj -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

COPY --from=build /publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "ClyvoVet.Api.dll"]