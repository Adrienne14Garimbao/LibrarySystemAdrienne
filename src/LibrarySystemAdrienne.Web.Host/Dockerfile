FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/LibrarySystemAdrienne.Web.Host/LibrarySystemAdrienne.Web.Host.csproj", "src/LibrarySystemAdrienne.Web.Host/"]
COPY ["src/LibrarySystemAdrienne.Web.Core/LibrarySystemAdrienne.Web.Core.csproj", "src/LibrarySystemAdrienne.Web.Core/"]
COPY ["src/LibrarySystemAdrienne.Application/LibrarySystemAdrienne.Application.csproj", "src/LibrarySystemAdrienne.Application/"]
COPY ["src/LibrarySystemAdrienne.Core/LibrarySystemAdrienne.Core.csproj", "src/LibrarySystemAdrienne.Core/"]
COPY ["src/LibrarySystemAdrienne.EntityFrameworkCore/LibrarySystemAdrienne.EntityFrameworkCore.csproj", "src/LibrarySystemAdrienne.EntityFrameworkCore/"]
WORKDIR "/src/src/LibrarySystemAdrienne.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/LibrarySystemAdrienne.Web.Host", "src/LibrarySystemAdrienne.Web.Host"]
COPY ["src/LibrarySystemAdrienne.Web.Core", "src/LibrarySystemAdrienne.Web.Core"]
COPY ["src/LibrarySystemAdrienne.Application", "src/LibrarySystemAdrienne.Application"]
COPY ["src/LibrarySystemAdrienne.Core", "src/LibrarySystemAdrienne.Core"]
COPY ["src/LibrarySystemAdrienne.EntityFrameworkCore", "src/LibrarySystemAdrienne.EntityFrameworkCore"]
WORKDIR "/src/src/LibrarySystemAdrienne.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "LibrarySystemAdrienne.Web.Host.dll"]
