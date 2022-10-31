FROM lancer1977/polyhydra-dotnet6

#LIBRARIES 
RUN apt update && apt-get install -y yt-dlp python3-brotli wget 

#ytdlrunner
RUN wget  https://github.com/lancer1977/ytdlp-runner/releases/download/alpha/ytdlrunner_0.0.4-4_all.deb
RUN dpkg  --force-all --install ytdlrunner_0.0.4-4_all.deb
RUN chown root /usr/bin/ytdlrunner
RUN chmod 777 /usr/bin/ytdlrunner

#USER SETUP
#RUN addgroup -S appgroup 
#RUN adduser runner
#USER runner
#WORKDIR /home/runner

#DOTNET INSTALL
#RUN wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
#RUN chmod +x dotnet-install.sh  
#RUN ./dotnet-install.sh -c Current

CMD /usr/bin/ytdlrunner