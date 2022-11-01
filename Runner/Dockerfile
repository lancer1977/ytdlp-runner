FROM lancer1977/polyhydra-dotnet6

ARG user=appuser
ARG group=appuser
ARG uid=1000
ARG gid=1000
RUN groupadd -g ${gid} ${group} && useradd -u ${uid} -g ${group} -s /bin/sh ${user}

#LIBRARIES 
RUN apt-get update && apt-get install -y yt-dlp python3-brotli wget cron dpkg

#ytdlrunner
RUN wget  https://github.com/lancer1977/ytdlp-runner/releases/download/alpha/ytdlrunner_0.0.4-4_all.deb
RUN apt install -f ./ytdlrunner_0.0.4-4_all.deb
 
RUN echo "0 3 * * * ytdlrunner >> /var/log/cron.log 2>&1" >> /etc/cron.d/restart-cron 
 
#Give the necessary rights to the user to run the cron
RUN crontab -u ${user} /etc/cron.d/restart-cron 
RUN chmod  u+s /usr/sbin/cron
 
# Create the log file to be able to run tail
RUN touch /var/log/cron.log     
 

COPY --chown=${user}:${user} . .

USER ${user}

# Run the command on container startup
CMD cron && tail -f /var/log/cron.log


#ENTRYPOINT [ "./entrypoint.sh" ]#
#CMD /usr/bin/ytdlrunner