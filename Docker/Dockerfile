FROM ubuntu

#install dependencies#LIBRARIES 
RUN apt-get update
RUN apt-get install -y dotnet6 dotnet-runtime-6.0
RUN apt-get install -y yt-dlp python3-brotli wget cron dpkg nano 
#Set timezone
ENV TZ=America/New_York
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

ARG user=appuser
ARG group=appuser
ARG uid=1000
ARG gid=1000
ENV CRONDEF='0 3 * * *'
ENV APPVERSION=8
ENV APPNAME=ytdlp-runner
ENV DEBUG=true
RUN groupadd -g ${gid} ${group} && useradd -u ${uid} -g ${group} -s /bin/sh -m ${user}
WORKDIR /home/${user}


RUN wget https://github.com/lancer1977/ytdlp-runner/releases/download/alpha/ytdlp-runner_0.0.${APPVERSION}-${APPVERSION}_all.deb -O ytdlp-runner.deb
RUN apt install -f ./ytdlp-runner.deb
 
 # Create the log file to be able to run tail
RUN touch /var/log/cron.log 
RUN rm -rf /etc/cron.*/*
RUN echo "${CRONDEF} su ${user} -c ${APPNAME} >/proc/1/fd/1 2>/proc/1/fd/2" >> /etc/cron.d/restart-cron
RUN 
RUN if [[ "$DEBUG" -eq "true" ]] ; then echo "* * * * * echo Its hammerin time! $(date) >/proc/1/fd/1 2>/proc/1/fd/2" >> /etc/cron.d/restart-cron ; fi
RUN echo \ >> /etc/cron.d/restart-cron 
RUN cat /etc/cron.d/restart-cron
#Give the necessary rights to the user to run the cron
RUN chmod 0644 /etc/cron.d/restart-cron
RUN crontab /etc/cron.d/restart-cron 

CMD ["cron","-f", "-l", "2"]