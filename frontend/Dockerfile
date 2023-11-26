FROM oven/bun:1.0-slim
ENV TZ=UTC
ENV ENV="/etc/profile"
RUN echo "UTC" > /etc/timezone
WORKDIR /frontend

COPY astro.config.mjs bun.lockb package.json tsconfig.json /frontend/
COPY public /frontend/public
COPY src /frontend/src

RUN bun install

ENV HOST=0.0.0.0
ENV PORT=4325
ENV ASTRO_TELEMETRY_DISABLED=1
CMD ["bun", "run", "astro", "dev", "--host", "$HOST", "--port", "$PORT"]
