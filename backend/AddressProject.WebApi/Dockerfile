FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AddressProject.WebApi/AddressProject.WebApi.csproj", "AddressProject.WebApi/"]
RUN dotnet restore "AddressProject.WebApi/AddressProject.WebApi.csproj"
COPY . .
WORKDIR "/src/AddressProject.WebApi"
RUN dotnet build "AddressProject.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AddressProject.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AddressProject.WebApi.dll"]
