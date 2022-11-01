#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Projeto_Teste_Hvex/Projeto_Teste_Hvex.csproj", "Projeto_Teste_Hvex/"]
RUN dotnet restore "Projeto_Teste_Hvex/Projeto_Teste_Hvex.csproj"
COPY . .
WORKDIR "/src/Projeto_Teste_Hvex"
RUN dotnet build "Projeto_Teste_Hvex.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Projeto_Teste_Hvex.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Projeto_Teste_Hvex.dll"]