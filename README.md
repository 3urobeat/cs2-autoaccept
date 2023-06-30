# csgo-autoaccept
This C# script automatically accepts CS:GO matches for you by analyzing your screen every 4 seconds and moving your mouse when it detects the 'Accept' button.  
Since this script does not interfere with any game files it should be completely VAC safe.  

This script is for Windows only. If you are on Linux see [my other repository for a Linux version.](https://github.com/3urobeat/csgo-autoaccept-cpp)  

![Screenshot](https://raw.githubusercontent.com/3urobeat/csgo-autoaccept/master/.github/img/showcase.png)  


## Download
**Easy way:**  
Head over to the [release section](https://github.com/3urobeat/csgo-autoaccept/releases/latest) and download the latest `.exe`.  
  
  
> Be aware that the Windows Defender likes to throw false-positives. While testing this `.exe` got flagged as a trojan multiple times even when building it directly on Windows.  
  
VirusTotal Scan: https://www.virustotal.com/gui/file/24b69361e5ec9ad580bf6bbbad5eed03938e0af6bbca00d3fbdfb706440758cc/detection  


**Slightly harder way if you don't trust the exe compiled by me:**  

Make sure to have the latest .NET Core SDK installed: https://dotnet.microsoft.com/download/dotnet/5.0  
With the SDK installed you can now compile this project yourself.  
Take a look at this comment if you want to compile it without having an IDE like Visual Studio or MonoDevelop installed: https://stackoverflow.com/a/18286923  
  
  
## Usage  
Start the script by executing the `.exe`.  
A terminal window will appear and the script will start scanning your screen every 4 seconds.  
Open CS:GO and queue for a match. The script will automatically accept it for you.  
  
When you are in the loading screen you can close the terminal window.  
If not everyone accepted just leave the script open and it will continue scanning.  

> The game must be on your Primary Display and focused. If you minimze the game the script won't work.  
