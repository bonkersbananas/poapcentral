FROM mcr.microsoft.com/dotnet/sdk:7.0-bookworm-slim
WORKDIR /backend

COPY api /backend/api

HEALTHCHECK --interval=10s --timeout=5s --start-period=30s --start-interval=1s --retries=5 \
    CMD curl --fail http://localhost:5196/healthz || exit

CMD ["dotnet", "watch", "--project", "api/"]
