FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["MediaService/MediaService.csproj", "MediaService/"]
RUN dotnet restore "MediaService/MediaService.csproj"
COPY . .
WORKDIR "/src/MediaService"
RUN dotnet build "MediaService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MediaService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MediaService.dll"]