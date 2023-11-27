FROM oven/bun:1.0-slim
ENV TZ=UTC
ENV ENV="/etc/profile"
RUN echo "UTC" > /etc/timezone

RUN apt-get update && \
    apt-get install -y curl && \
    rm -rf /var/lib/apt/lists/*

WORKDIR /frontend

COPY astro.config.mjs bun.lockb package.json tsconfig.json /frontend/
COPY public /frontend/public
COPY src /frontend/src

RUN bun install

ENV PORT=4321
ENV ASTRO_TELEMETRY_DISABLED=1

HEALTHCHECK --interval=10s --timeout=5s --start-period=30s --retries=5 \
    CMD curl --fail http://localhost:$PORT/healthz || exit

CMD ["bun", "run", "astro", "dev", "--host", "--port", "$PORT"]
# CMD ["bun", "--inspect=ws://0.0.0.0:9229/oftfxo1yy3", "node_modules/astro/astro.js", "dev", "--host", "--port", "$PORT"]
