#!/bin/sh
echo ENTRY RUNNING
cron -L 15
tail -f /var/log/cron.log
