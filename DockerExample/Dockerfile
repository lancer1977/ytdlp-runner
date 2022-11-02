# Pulling Ubuntu image
FROM ubuntu:20.04
WORKDIR /root
# Updating packages and installing cron
RUN apt-get update && apt-get install cron nano -y 

# Copying script file into the container. 
RUN touch /var/log/cron.log 
COPY crontab /etc/cron.d/entry
RUN chmod 644 /etc/cron.d/entry
RUN crontab   /etc/cron.d/entry
COPY entry.sh entry.sh 
RUN chmod +x entry.sh

COPY runner.sh runner.sh 
RUN chmod +x runner.sh
RUN crontab -l
# Adding crontab to the appropiate location
#RUN crontab -l | { cat; echo "* * * * * root sh entrypoint.sh"; } | crontab -
 
HEALTHCHECK --interval=5s --timeout=3s \
    CMD ps aux | grep '[c]ron' || exit 1 

ENTRYPOINT entry.sh