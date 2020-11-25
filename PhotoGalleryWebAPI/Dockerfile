FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PhotoGalleryWebAPI.csproj", "PhotoGalleryWebAPI.csproj"]
RUN dotnet restore "PhotoGalleryWebAPI.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "PhotoGalleryWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PhotoGalleryWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "PhotoGalleryWebAPI.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet PhotoGalleryWebAPI.dll