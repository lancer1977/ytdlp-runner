FROM ubuntu

RUN apt update
RUN apt-get install -y dotnet6 
RUN apt-get install -y dotnet-runtime-6.0
ARG user=appuser
ARG group=appuser
ARG uid=1000
ARG gid=1000
ARG cron_arg='0 3 * * *'
ARG appversion_arg=8
ENV cron=${cron_arg}
ENV appversion=${appversion_arg}
RUN groupadd -g ${gid} ${group} && useradd -u ${uid} -g ${group} -s /bin/sh -m ${user}
WORKDIR /home/${user}

#LIBRARIES 
RUN apt-get update && apt-get install -y yt-dlp python3-brotli wget cron dpkg nano
RUN wget  https://github.com/lancer1977/ytdlp-runner/releases/download/alpha/ytdlp-runner_0.0.${appversion}-${appversion}_all.deb -o ytdlp-runner.deb
RUN apt install -f ./ytdlp-runner.deb
 
 # Create the log file to be able to run tail
RUN touch /var/log/cron.log 
RUN rm -rf /etc/cron.*/*
RUN echo "${cron} su ${user} -c ytdlp-runner >/proc/1/fd/1 2>/proc/1/fd/2" >> /etc/cron.d/restart-cron
#RUN echo "* * * * * su root -c echo "${CUSTOM_ENV_VAR}" >/proc/1/fd/1 2>/proc/1/fd/2" >> /etc/cron.d/restart-cron
RUN echo \ >> /etc/cron.d/restart-cron 
RUN cat /etc/cron.d/restart-cron
#Give the necessary rights to the user to run the cron
RUN chmod 0644 /etc/cron.d/restart-cron
RUN crontab /etc/cron.d/restart-cron 

CMD ["cron","-f", "-l", "2"]