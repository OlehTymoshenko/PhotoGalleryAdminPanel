FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PhotoGalleryAdminPanel.csproj", "PhotoGalleryAdminPanel.csproj"]
RUN dotnet restore "PhotoGalleryAdminPanel.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "PhotoGalleryAdminPanel.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PhotoGalleryAdminPanel.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "PhotoGalleryAdminPanel.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet PhotoGalleryAdminPanel.dll