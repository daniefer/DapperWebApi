FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["DapperWebApi/DapperWebApi.csproj", "DapperWebApi/"]
RUN dotnet restore "DapperWebApi/DapperWebApi.csproj"
COPY . .
WORKDIR "/src/DapperWebApi"
RUN dotnet build "DapperWebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DapperWebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DapperWebApi.dll"]