FROM oven/bun:1.0-slim
WORKDIR /frontend

COPY astro.config.mjs bun.lockb package.json tsconfig.json /frontend/
COPY public /frontend/public
COPY src /frontend/src

RUN bun install

# ENV HOST=0.0.0.0
ENV PORT=4321
ENV ASTRO_TELEMETRY_DISABLED=1
CMD ["bun", "run", "astro", "dev"]
