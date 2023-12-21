#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VariacaoAtivoFixo/VariacaoAtivoFixo.API.csproj", "VariacaoAtivoFixo/"]
COPY ["VariacaoAtivoFixo.Application/VariacaoAtivoFixo.Application.csproj", "VariacaoAtivoFixo.Application/"]
COPY ["VariacaoAtivoFixo.Domain/VariacaoAtivoFixo.Domain.csproj", "VariacaoAtivoFixo.Domain/"]
COPY ["VariacaoAtivoFixo.Service/VariacaoAtivoFixo.Services.csproj", "VariacaoAtivoFixo.Service/"]
COPY ["VariacaoAtivoFixo.IOC/VariacaoAtivoFixo.IOC.csproj", "VariacaoAtivoFixo.IOC/"]
COPY ["VariacaoAtivoFixo.Infra/VariacaoAtivoFixo.Infra.csproj", "VariacaoAtivoFixo.Infra/"]
RUN dotnet restore "VariacaoAtivoFixo/VariacaoAtivoFixo.API.csproj"
COPY . .
WORKDIR "/src/VariacaoAtivoFixo"
RUN dotnet build "VariacaoAtivoFixo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VariacaoAtivoFixo.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VariacaoAtivoFixo.API.dll"]