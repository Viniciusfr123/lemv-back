FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:8000;http://+80;

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LEMV.Api/LEMV.Api.csproj", "LEMV.Api/"]
COPY ["LEMV.Data/LEMV.Data.csproj", "LEMV.Data/"]
COPY ["LEMV.Domain/LEMV.Domain.csproj", "LEMV.Domain/"]
COPY ["LEMV.Application/LEMV.Application.csproj", "LEMV.Application/"]
RUN dotnet restore "LEMV.Api/LEMV.Api.csproj"
COPY . .
WORKDIR "/src/LEMV.Api"
RUN dotnet build "LEMV.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LEMV.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LEMV.Api.dll"]