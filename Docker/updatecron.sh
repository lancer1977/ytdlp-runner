#!/bin/sh
#Update YT-DLP-Runner
wget https://github.com/lancer1977/ytdlp-runner/releases/download/alpha/ytdlp-runner_0.0.${appversion}-${appversion}_all.deb -O ytdlp-runner.deb
apt install -f ./ytdlp-runner.deb

#update cron
rm -rf /etc/cron.*/*
echo "$crondef runner.sh" >> /etc/cron.d/restart-cron
echo \ >> /etc/cron.d/restart-cron 
cat /etc/cron.d/restart-cron
#Give the necessary rights to the user to run the cron
chmod 0644 /etc/cron.d/restart-cron
crontab /etc/cron.d/restart-cron 

echo "5 * * * * flock /var/runner.lock runner.sh" >> /etc/cron.d/restart-cron