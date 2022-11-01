FROM lancer1977/polyhydra-dotnet6

#LIBRARIES 
RUN apt-get update && apt-get install -y yt-dlp python3-brotli wget cron dpkg

#ytdlrunner
RUN wget  https://github.com/lancer1977/ytdlp-runner/releases/download/alpha/ytdlrunner_0.0.4-4_all.deb
RUN apt install -f ./ytdlrunner_0.0.4-4_all.deb
#RUN chown root /usr/bin/ytdlrunner
#RUN chmod 777 /usr/bin/ytdlrunner
#RUN mkdir /root/.ytdlrunner && mkdir /root/YTOutput
#RUN chmod 777 /root/.ytdlrunner && chmod 777 /root/YTOutput

RUN adduser runner

run echo "0 3 * * * ytdlrunner >> /var/log/cron.log 2>&1" >> /etc/cron.d/restart-cron 
   
    # Give the necessary rights to the user to run the cron
    RUN crontab -u runner /etc/cron.d/restart-cron 
    RUN chmod u+s /usr/sbin/cron
 
# Create the log file to be able to run tail
RUN touch /var/log/cron.log     
 
COPY --chown=runner:runner . .

USER runner

# Run the command on container startup
CMD cron && tail -f /var/log/cron.log


ENTRYPOINT [ "./entrypoint.sh" ]
#CMD /usr/bin/ytdlrunner