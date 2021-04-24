FROM node:10 AS builder
WORKDIR /app
COPY . .
RUN npm i && npm run build

FROM nginx:alpine AS server
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*
COPY --from=builder /app/dist/acelera-quiz .
ENTRYPOINT ["nginx", "-g", "daemon off;"]