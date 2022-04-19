FROM nginx:alpine

WORKDIR /etc/nginx/conf.d
COPY webgl.conf default.conf

RUN mkdir -p /var/www
WORKDIR /var/www
