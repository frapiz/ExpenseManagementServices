FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 54619
EXPOSE 44396

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ExpenseManagementServices/ExpenseManagementServices.csproj ExpenseManagementServices/
RUN dotnet restore ExpenseManagementServices/ExpenseManagementServices.csproj
COPY . .
WORKDIR /src/ExpenseManagementServices
RUN dotnet build ExpenseManagementServices.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ExpenseManagementServices.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ExpenseManagementServices.dll"]
