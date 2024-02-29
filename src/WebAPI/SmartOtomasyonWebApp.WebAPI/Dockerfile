#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/WebAPI/SmartOtomasyonWebApp.WebAPI/SmartOtomasyonWebApp.WebAPI.csproj", "src/WebAPI/SmartOtomasyonWebApp.WebAPI/"]
COPY ["src/Core/SmartOtomasyonWebApp.Application/SmartOtomasyonWebApp.Application.csproj", "src/Core/SmartOtomasyonWebApp.Application/"]
COPY ["src/Core/SmartOtomasyonWebApp.Domain/SmartOtomasyonWebApp.Domain.csproj", "src/Core/SmartOtomasyonWebApp.Domain/"]
COPY ["src/Infrastructure/SmartOtomasyonWebApp.Persistance/SmartOtomasyonWebApp.Persistance.csproj", "src/Infrastructure/SmartOtomasyonWebApp.Persistance/"]
RUN dotnet restore "src/WebAPI/SmartOtomasyonWebApp.WebAPI/SmartOtomasyonWebApp.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/WebAPI/SmartOtomasyonWebApp.WebAPI"
RUN dotnet build "SmartOtomasyonWebApp.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartOtomasyonWebApp.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartOtomasyonWebApp.WebAPI.dll"]