FROM alpine:latest
RUN apk update && apk add dpkg yt-dlp py3-brotli bash
RUN wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
RUN chmod +x dotnet-install.sh  
RUN ./dotnet-install.sh -c Current
RUN wget  https://github.com/lancer1977/ytdlp-runner/releases/download/Linux/yt-dl-runner_0.0.2-2_all.deb
RUN dpkg  --force-all --install yt-dl-runner_0.0.2-2_all.deb
RUN addgroup -S appgroup && adduser -S appuser -G appgroup

ENTRYPOINT ["YTDLRunner"]