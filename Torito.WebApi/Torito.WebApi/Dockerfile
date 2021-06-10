#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Torito.WebApi/Torito.WebApi/Torito.WebApi.csproj", "Torito.WebApi/Torito.WebApi/"]
COPY ["Torito.Core/Torito.Core.csproj", "Torito.Core/"]
COPY ["Gmaps.Client/Gmaps.Client.csproj", "Gmaps.Client/"]
COPY ["Torito.Models/Torito.Models.csproj", "Torito.Models/"]
COPY ["Torito.Data/Torito.Data.csproj", "Torito.Data/"]
COPY ["TwitterClient/TwitterClient/TwitterClient.csproj", "TwitterClient/TwitterClient/"]
RUN dotnet restore "Torito.WebApi/Torito.WebApi/Torito.WebApi.csproj"
COPY . .
WORKDIR "/src/Torito.WebApi/Torito.WebApi"
RUN dotnet build "Torito.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Torito.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Torito.WebApi.dll"]