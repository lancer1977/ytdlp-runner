dotnet publish Runner/*.csproj --configuration Release -r linux-x64 -p:PublishSingleFile=true --self-contained true --output tmp

workdir=~/ytdlp-runner_0.0.$1-$1_all
echo $workdir
mkdir -p $workdir/usr/bin
cp tmp/ytdlp-runner $workdir/usr/bin/ytdlp-runner

mkdir -p $workdir/DEBIAN
chmod 755 $workdir/DEBIAN
touch tmpcontrol  
echo "Package: ytdlp-runner" >> tmpcontrol
echo "Version: 0.0.$1" >> tmpcontrol
echo "Maintainer: lancer1977@gmail.com" >> tmpcontrol
echo "Depends: " >> tmpcontrol
echo "Architecture: all" >> tmpcontrol
echo "Homepage: http://polyhydragames.com" >> tmpcontrol
echo "Description: A program that runs multiple calls to yt-dlp to grab multiple shows." >> tmpcontrol

cp tmpcontrol $workdir/DEBIAN/control
rm tmpcontrol
cat $workdir/DEBIAN/control
dpkg --build $workdir

gh release upload alpha ~/ytdlp-runner_0.0.$1-$1_all.deb -R https://github.com/lancer1977/ytdlp-runner
