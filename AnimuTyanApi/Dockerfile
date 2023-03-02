#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AnimuTyanApi/AnimuTyanApi.csproj", "AnimuTyanApi/"]
RUN dotnet restore "AnimuTyanApi/AnimuTyanApi.csproj"
COPY . .
WORKDIR "/src/AnimuTyanApi"
RUN dotnet build "AnimuTyanApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AnimuTyanApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development 
ENTRYPOINT ["dotnet", "AnimuTyanApi.dll"]