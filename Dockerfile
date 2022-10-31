FROM Alpine
run dpkg update && \
    dpkg install -y python3-brotli yt-dlp dotnet-sdk.6.0