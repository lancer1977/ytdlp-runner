FROM alpine:latest

RUN apk update && apk add dpkg yt-dlp py3-brotli bash 
RUN apk add bash icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib
RUN apk add libgdiplus --repository https://dl-3.alpinelinux.org/alpine/edge/testing/

RUN wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
RUN chmod +x dotnet-install.sh  
RUN ./dotnet-install.sh -c Current
RUN wget  https://github.com/lancer1977/ytdlp-runner/releases/download/V3/ytdlrunner_0.0.3-3_all.deb
RUN dpkg  --force-all --install ytdlrunner_0.0.3-3_all.deb
RUN chown root /usr/bin/ytdlrunner
RUN chmod  /usr/bin/ytdlrunner
RUN addgroup -S appgroup && adduser -S runner -G appgroup
USER runner

ENTRYPOINT ["ytdlrunner"]