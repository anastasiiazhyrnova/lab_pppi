FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
RUN apk update && apk add libgdiplus
RUN apk update && apk add fontconfig ttf-liberation
RUN apk add ttf-freefont && apk add libssl1.1
RUN fc-cache -f -v

WORKDIR /app
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebAPI_Labs/WebAPI_Labs.csproj", "WebAPI_Labs/"]
RUN dotnet restore "WebAPI_Labs/WebAPI_Labs.csproj"
COPY . .
WORKDIR "/src/WebAPI_Labs"
RUN dotnet build "WebAPI_Labs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI_Labs.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI_Labs.dll"]