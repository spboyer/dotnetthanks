ARG sourceversion=00000

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["dotnetthanks.csproj", "./"]
RUN dotnet restore "dotnetthanks.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "dotnetthanks.csproj" -c Release -o /app/build /p:SourceRevisionId=$sourceversion

FROM build AS publish
RUN dotnet publish "dotnetthanks.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnetthanks.dll"]
