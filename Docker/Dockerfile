FROM lancer1977/ytdlp_runner_base:latest
ENV crondef="0 3 * * *"
ENV appversion=11
ENV appname=ytdlp-runner

WORKDIR /root

RUN wget https://github.com/lancer1977/ytdlp-runner/releases/download/alpha/ytdlp-runner_0.0.${appversion}-${appversion}_all.deb -O ytdlp-runner.deb
RUN apt install -f ./ytdlp-runner.deb

COPY entrypoint.sh /root
RUN chmod +x /root/entrypoint.sh
COPY updatecron.sh /root
RUN chmod +x /root/updatecron.sh

 # Create the log file to be able to run tail
RUN touch /var/log/cron.log 
RUN rm -rf /etc/cron.*/*

ENTRYPOINT [ "/root/entrypoint.sh" ]