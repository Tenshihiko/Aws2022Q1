#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Aws2022Q1/Aws2022Q1.csproj", "Aws2022Q1/"]
RUN dotnet restore "Aws2022Q1/Aws2022Q1.csproj"
COPY . .
WORKDIR "/src/Aws2022Q1"
RUN dotnet build "Aws2022Q1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aws2022Q1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aws2022Q1.dll"]