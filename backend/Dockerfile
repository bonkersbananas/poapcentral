FROM mcr.microsoft.com/dotnet/sdk:7.0-bookworm-slim
WORKDIR /backend
COPY api /backend/api
HEALTHCHECK CMD curl --fail http://localhost:5196/healthz || exit
CMD ["dotnet", "watch", "--project", "api/"]
