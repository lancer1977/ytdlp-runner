FROM ubuntu

#install dependencies#LIBRARIES 
RUN apt-get update
RUN apt-get install -y dotnet6 dotnet-runtime-6.0 yt-dlp python3-brotli wget cron dpkg nano 
#Set timezone
ENV TZ=America/New_York
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

ARG user=appuser
ARG group=appuser
ARG uid=1000
ARG gid=1000
ENV crondef="0 3 * * *"
ENV appversion=11
ENV appname=ytdlp-runner
ENV debug=true
RUN groupadd -g ${gid} ${group} && useradd -u ${uid} -g ${group} -s /bin/sh -m ${user}
WORKDIR /root

COPY entrypoint.sh /root
RUN chmod +x /root/entrypoint.sh
COPY updatecron.sh /root
RUN chmod +x /root/updatecron.sh

 # Create the log file to be able to run tail
RUN touch /var/log/cron.log 
RUN rm -rf /etc/cron.*/*

ENTRYPOINT [ "/root/entrypoint.sh" ]