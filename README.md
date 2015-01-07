# ScreenResolutionChanger
Sets the Screen Resolution of the specified monitor in single or multi-monitor setups. Uses Pinvoke and multiple Win32 API features to make the changes. Written in C#. PowerShell Function also provided.

Tested with Windows 7. Requires PowerShell v2 for the PowerShell Function.

PowerShell Function also avalible on Microsoft TechNet Script Center (https://gallery.technet.microsoft.com/scriptcenter/Set-ScreenResolutionEx-54c5de59).

<h2>Directory</h2>
C# Script - The C# standalone C# script
PowerShell Function - The PowerShell Function
FindDispNum Tool - A simple tool written in C# that will show all the display information for the computer including the DeviceID needed to run the script and function. 

<h3>FindDispNum Tool Instructions</h3>
1) Run the .exe from cmd.
2) Identify the DeviceID of the monitor you want to make changes to.

<h2>Acknowledgements</h2>
-Many thanks to Andy Schneider for providing the original code for a single monitor (https://gallery.technet.microsoft.com/ScriptCenter/2a631d72-206d-4036-a3f2-2e150f297515/). 
-Thanks to <a href="http://www.pinvoke.net" target="_blank">PInvoke.net</a> for having an amazing resource for PInvoke and Win32.


