FROM microsoft/aspnetcore-build:2 as BUILD
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app ./src/ValuesService/ValuesService.csproj

FROM microsoft/aspnetcore:2
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "ValuesService.dll"]