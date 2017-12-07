FROM microsoft/aspnetcore-build-nightly as BUILD
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app ./src/WebUI/WebUI.csproj

FROM microsoft/aspnetcore-nightly
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "WebUI.dll"]