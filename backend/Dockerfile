FROM mcr.microsoft.com/dotnet/sdk:7.0-bookworm-slim
WORKDIR /backend

COPY api /backend/api
RUN dotnet restore api/
HEALTHCHECK --interval=10s --timeout=5s --start-period=30s --retries=5 \
    CMD curl --fail http://localhost:5196/healthz || exit

CMD ["dotnet", "watch", "--project", "api/"]
