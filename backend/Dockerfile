FROM mcr.microsoft.com/dotnet/sdk:7.0-bookworm-slim
ENV TZ=UTC
ENV ENV="/etc/profile"
RUN echo "UTC" > /etc/timezone

RUN apt update && \
    apt install -y unzip procps && \
    curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l /remote_debugger && \
    rm -rf /var/lib/apt/lists/*

RUN dotnet tool install --tool-path /usr/local/bin/ dotnet-symbol

WORKDIR /backend

COPY api/PoapCentralApi.csproj api/Directory.Build.props /backend/api/
RUN dotnet restore api/

COPY api /backend/api
RUN dotnet build --debug --no-restore --output build api/

HEALTHCHECK --interval=10s --timeout=5s --start-period=30s --retries=5 \
    CMD curl --fail --connect-timeout 1 --max-time 3 http://localhost:5196/healthz || exit

ENV ASPNETCORE_URLS=http://0.0.0.0:5196
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_DETAILEDERRORS=1
ENV ASPNETCORE_SHUTDOWNTIMEOUTSECONDS=1

CMD ["build/PoapCentralApi"]
# CMD ["dotnet", "run", "--project", "api/", "--configuration", "Debug"]
