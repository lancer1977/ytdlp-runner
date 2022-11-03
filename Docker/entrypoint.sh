#!/bin/sh
echo "Updating Cron"
/root/updatecron.sh
echo "cron started"

# Run forever
#tail -f /dev/null

cron -f >> /var/log/cron.log