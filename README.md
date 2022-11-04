# YT-DLP Runner

## What is it?

A C# app that interops with YT-DLP to help maintain a ongoing updated repository of favorite playlists etc.

## How It Works

1. Using a list of links and arguments provided in the settings file the app simply builds commands and executes YT-DLP.

# Why
I found myself reading a ton of websites that were causing me more anxiety when I just wanted to know how the daily trends were progressing. Initially I started with a console app and ended up with a mobile app instead due to the deploy anywhere nature of Xamarin (forms).

# How to Use
After the app runs initially it will seting the needed files if they don't exist already. the settings are stored in JSON format with a Sources list that you can add additional lists to follow.

## Linux
Setting Files: /home/[user]/.ytdlprunner 

## Windows
Setting Files: %AppData$\.ytdlprunner 
# Latest Build
 ### Docker
    https://hub.docker.com/r/lancer1977/ytdlprunner
    docker push lancer1977/ytdlprunner:tagname

 ### Linux
    https://github.com/lancer1977/ytdlp-runner/releases/download/alpha/ytdlp-runner_0.0.11-11_all.deb

 ### Windows
    Soon! 
# Contact Us
lancer1977@gmail.com
