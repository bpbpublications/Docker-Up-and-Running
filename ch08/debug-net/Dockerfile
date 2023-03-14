FROM mcr.microsoft.com/dotnet/runtime:5.0-focal AS base
WORKDIR /app

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["debug-net.csproj", "./"]
RUN dotnet restore "debug-net.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "debug-net.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "debug-net.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "debug-net.dll"]
