FROM mcr.microsoft.com/dotnet/sdk:5.0-focal
WORKDIR /src
COPY App/App.csproj ./App/
COPY UnitTests/UnitTests.csproj ./UnitTests/
RUN dotnet restore UnitTests
COPY App ./App
COPY UnitTests ./UnitTests
CMD dotnet watch test --project UnitTests