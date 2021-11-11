FROM mcr.microsoft.com/dotnet/sdk:5.0.403-alpine3.13-amd64 AS appbuild

WORKDIR /app
COPY Deformed-Bot-API-dotnet.csproj .
RUN dotnet restore 
COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0.12-alpine3.14-amd64
COPY --from=appbuild ./app/out .
EXPOSE 80

CMD ["dotnet","Deformed-Bot-API-dotnet.dll"]

