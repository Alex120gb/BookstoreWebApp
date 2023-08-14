#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443



FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BookstoreWebApp/BookstoreWebApp.csproj", "BookstoreWebApp/"]
RUN mkdir -p /nuget-local
COPY ./Release/Bookstore.Api.SDK.5.0.1.nupkg /nuget-local/
RUN dotnet nuget add source /nuget-local -n LocalNuGet
RUN dotnet restore "BookstoreWebApp/BookstoreWebApp.csproj"
COPY . .
WORKDIR "/src/BookstoreWebApp"
RUN dotnet build "BookstoreWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookstoreWebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookstoreWebApp.dll"]