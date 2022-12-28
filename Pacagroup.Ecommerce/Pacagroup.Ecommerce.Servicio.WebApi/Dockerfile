FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env 
WORKDIR /src 
COPY . . 
WORKDIR /src/Pacagroup.Ecommerce.Servicio.WebApi 
RUN dotnet restore 
RUN dotnet publish -c Release -o out 

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 
WORKDIR /app
COPY --from=build-env /src/Pacagroup.Ecommerce.Servicio.WebApi/out ./

ENTRYPOINT ["dotnet", "Pacagroup.Ecommerce.Servicio.WebApi.dll"]