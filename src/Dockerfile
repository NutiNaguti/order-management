FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY /order-management/bin/Debug/net5.0/publish ../order-management
WORKDIR /order-management
ENV COMPlus_EnableDiagnostics=0
ENTRYPOINT ["dotnet", "order-management.dll"]