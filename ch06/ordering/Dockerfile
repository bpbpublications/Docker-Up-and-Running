FROM mcr.microsoft.com/dotnet/sdk:5.0 AS builder
WORKDIR /app
COPY . .
RUN dotnet build -c Release -o output

FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY --from=builder /app/output /app
CMD ["dotnet", "/app/ordering.dll"]
