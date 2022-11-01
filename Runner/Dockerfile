FROM lancer1977/polyhydra-dotnet6

#LIBRARIES 
RUN apt-get update && apt-get install -y yt-dlp python3-brotli wget cron dpkg

#ytdlrunner
RUN wget  https://github.com/lancer1977/ytdlp-runner/releases/download/alpha/ytdlrunner_0.0.4-4_all.deb
RUN apt install -f ./ytdlrunner_0.0.4-4_all.deb
RUN chown root /usr/bin/ytdlrunner
RUN chmod 777 /usr/bin/ytdlrunner
RUN mkdir /root/.ytdlrunner && mkdir /root/YTOutput
RUN chmod 777 /root/.ytdlrunner && chmod 777 /root/YTOutput
 
# Copy hello-cron file to the cron.d directory
COPY ytdlp-cron /etc/cron.d/ytdlp-cron 
# Give execution rights on the cron job
RUN chmod 0644 /etc/cron.d/ytdlp-cron

# Apply cron job
RUN crontab /etc/cron.d/ytdlp-cron
 
# Create the log file to be able to run tail
RUN touch /var/log/cron.log
 
# Run the command on container startup
CMD cron && tail -f /var/log/cron.log

#CMD /usr/bin/ytdlrunner