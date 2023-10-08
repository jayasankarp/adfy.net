FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Adfy.Application/Adfy.Application.csproj", "Adfy.Application/"]
RUN dotnet restore "Adfy.Application/Adfy.Application.csproj"
COPY . .
WORKDIR "/src/Adfy.Application"
RUN dotnet build "Adfy.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Adfy.Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Adfy.Application.dll"]
