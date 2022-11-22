#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# foi feito alteração do meu arquivo DockerFile e a porta que foi inicializada
# foi feito adicionada configuração de ambiente
ENV ASPNETCORE_URLS=http://+:44335;http://+:80; # a ponta para url e a porta q vai ser usada
ENV ASPNETCORE_ENVIRONMENT=Development 


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src # adicionada a referencia para efetuar copia das camadas Data e Domain, para nao quebrar o builder da imagem do Docker
COPY ["Projeto_Teste_Hvex/Projeto_Teste_Hvex.csproj", "Projeto_Teste_Hvex/"]
COPY ["Projeto_Teste_Hvex.Data/Projeto_Teste_Hvex.Data.csproj", "Projeto_Teste_Hvex.Data/"]
COPY ["Projeto_Teste_Hvex.Domain/Projeto_Teste_Hvex.Domain.csproj", "Projeto_Teste_Hvex.Domain/"]
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