echo "Start cron"
#cron
echo "cron started"

# Run forever
#tail -f /dev/null
#!/bin/sh

env >> /etc/environment

# execute CMD
echo "$@"
exec "$@"