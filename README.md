# YT-DLP Runner

## What is it?

A C# app that interops with YT-DLP to help maintain a ongoing updated repository of favorite playlists etc.

## How It Works

1. Using a list of links and arguments provided in the settings file the app simply builds commands and executes YT-DLP.

# Why
I found myself reading a ton of websites that were causing me more anxiety when I just wanted to know how the daily trends were progressing. Initially I started with a console app and ended up with a mobile app instead due to the deploy anywhere nature of Xamarin (forms).

# How to Use
After the app runs initially it will seting the needed files if they don't exist already. 

## Linux
Setting Files: /home/[user]/.ytdlprunner 

## Windows
Setting Files: /home/[user]/.ytdlprunner 
# Latest Build
 ### Docker
    https://hub.docker.com/r/lancer1977/ytdlprunner
    docker push lancer1977/ytdlprunner:tagname

 ### Linux
    https://github.com/lancer1977/ytdlp-runner/releases/download/alpha/ytdlrunner_0.0.4-4_all.deb

 ### Windows
    Soon!
# Data Sources
Data from The New York Times, based on reports from state and local health agencies.
https://raw.githubusercontent.com/nytimes/covid-19-data/master/us-counties.csv

# Contact Us
lancer1977@gmail.com
