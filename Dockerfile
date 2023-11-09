FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

COPY ./src ./

WORKDIR /src/Products.WebApi

RUN dotnet restore

RUN dotnet publish -c Release -o output

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS serve
WORKDIR /app
COPY --from=build /src/Products.WebApi/output .

EXPOSE 80
EXPOSE 443

ENTRYPOINT [ "dotnet", "Products.WebApi.dll" ]