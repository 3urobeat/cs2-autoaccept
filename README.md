# cs2-autoaccept
This C# script automatically accepts Counter-Strike 2 matches for you.  
It does this by analyzing your screen every 4 seconds and moving and clicking with your mouse when it detects the 'Accept' button.  
Since this script does not interfere with any game files and just takes screenshots of your display it is completely VAC safe.  

This script is for Windows only. If you are on Linux, please see [my other repository.](https://github.com/3urobeat/cs2-autoaccept-linux)  

![Screenshot](https://raw.githubusercontent.com/3urobeat/cs2-autoaccept/master/.github/img/showcase.png)  

&nbsp;

## Download
**Easy way:**  
Head over to the [release section](https://github.com/3urobeat/cs2-autoaccept/releases/latest) and download the latest `.exe`.  
  
> Be aware that the Windows Defender likes to throw false-positives. While testing, this `.exe` got flagged as a trojan multiple times even when building it on the very same device.  
  
VirusTotal Scan: [Click](https://www.virustotal.com/gui/file-analysis/YjQ1YzcxMmZlYjE0N2EyMzM3YTU2NzY4MDJhN2Q2Zjk6MTY5OTcyMzI2Mg==/detection)  

&nbsp;

**Slightly harder way if you want to compile this project yourself:**  
Install Visual Studio with the .NET-Desktop-Development package.  
Open the `cs2-autoaccept.sln` file and compile the project by selecting "Release" at the top and then hitting F6.  
Your compiled .exe file will now be inside the `./bin/Release` folder. Copy it to anywhere you like.

You can probably also compile this project without the full Visual Studio editor installed, but I don't know exactly how.  
(I usually develop on Linux)

&nbsp;

## Usage  
Start the script by executing the `.exe`.  
A terminal window will appear and the script will start scanning your screen every 4 seconds.  
Queue for a match in CS2 and the script will automatically accept it for you.  
  
Once you are in the loading screen, you can close the terminal window, it will otherwise continue searching.

> The game must be on your **primary display** and be focused. If you minimze the game the script won't work.  
> The script works in Windowed, as well as in Fullscreen and isn't affected by your brightness settings.

&nbsp;

Enjoy a toilet break while queueing!
