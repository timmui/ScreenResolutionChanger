//-----------------------------------------------------------------------------
// Description: Shows display information on the current computer
// 
// Author: Timothy Mui (https://github.com/timmui)
//
// Date: Jan. 7, 2015
//
// Acknowledgements: Thanks to PInvoke.net (http://www.pinvoke.net/) for the
//                   extremely helpful resource.
//-----------------------------------------------------------------------------
using System; 
using System.Runtime.InteropServices; 
 
class Resolution
{
	[Flags()]
	public enum DisplayDeviceStateFlags : int
	{
		/// <summary>The device is part of the desktop.</summary>
		AttachedToDesktop = 0x1,
		MultiDriver = 0x2,
		/// <summary>The device is part of the desktop.</summary>
		PrimaryDevice = 0x4,
		/// <summary>Represents a pseudo device used to mirror application drawing for remoting or other purposes.</summary>
		MirroringDriver = 0x8,
		/// <summary>The device is VGA compatible.</summary>
		VGACompatible = 0x10,
		/// <summary>The device is removable; it cannot be the primary display.</summary>
		Removable = 0x20,
		/// <summary>The device has more display modes than its output devices support.</summary>
		ModesPruned = 0x8000000,
		Remote = 0x4000000,
		Disconnect = 0x2000000
	}
	
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    public struct DISPLAY_DEVICE 
    {
        [MarshalAs(UnmanagedType.U4)]
        public int cb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
        public string DeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
        public string DeviceString;
        [MarshalAs(UnmanagedType.U4)]
        public DisplayDeviceStateFlags StateFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
        public string DeviceID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=128)]
        public string DeviceKey;
    }
	
	[DllImport("user32.dll")]
	public static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);  
		
	static void Main ()
	{
		DISPLAY_DEVICE d=new DISPLAY_DEVICE();
		d.cb=Marshal.SizeOf(d);
		try {
			for (uint id=0; EnumDisplayDevices(null, id, ref d, 0); id++) {
				Console.WriteLine("ID: {0}\nDeviceName: {1} \nDeviceString: {2}\nDeviceID: {3}\nDeviceKey {4}\nStateFlags {5}\n",id, d.DeviceName, d.DeviceString, d.DeviceID, d.DeviceKey, d.StateFlags);
				Console.WriteLine("--------------------------------------------------------------------------------");
				d.cb=Marshal.SizeOf(d);
			}
		} catch (Exception ex) {
			Console.WriteLine(String.Format("{0}",ex.ToString()));
		}
	}
}
