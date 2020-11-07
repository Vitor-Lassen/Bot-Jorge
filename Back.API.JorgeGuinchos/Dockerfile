#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Back.API.JorgeGuinchos/Back.API.JorgeGuinchos.csproj", "Back.API.JorgeGuinchos/"]
RUN dotnet restore "Back.API.JorgeGuinchos/Back.API.JorgeGuinchos.csproj"
COPY . .
WORKDIR "/src/Back.API.JorgeGuinchos"
RUN dotnet build "Back.API.JorgeGuinchos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Back.API.JorgeGuinchos.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Back.API.JorgeGuinchos.dll"]