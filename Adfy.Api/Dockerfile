FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Adfy.Api/Adfy.Api.csproj", "Adfy.Api/"]
RUN dotnet restore "Adfy.Api/Adfy.Api.csproj"
COPY . .
WORKDIR "/src/Adfy.Api"
RUN dotnet build "Adfy.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adfy.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adfy.Api.dll"]
