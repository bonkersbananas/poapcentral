FROM oven/bun:1.0-slim
WORKDIR /frontend

COPY astro.config.mjs bun.lockb package.json tsconfig.json /frontend/
COPY public /frontend/public
COPY src /frontend/src

RUN bun install
RUN bun run astro telemetry disable

ENV HOST=0.0.0.0
ENV PORT=4321
CMD ["bun", "run", "astro", "dev"]
