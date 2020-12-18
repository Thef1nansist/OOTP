using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB013
{
    public static class SVYDiskInfo
    {
        public static string GetDiskInfo()
        {
            IEnumerable<DriveInfo> driveInfos = DriveInfo.GetDrives();
            string output = "";

            foreach(var dr in driveInfos)
            {
                output += $"Name: {dr.Name}\n";
                output += $"Driver type: {dr.DriveType}\n";
                if (dr.IsReady == true)
                {
                    output += $"  Volume label: {dr.VolumeLabel}\n";
                    output += $"  File system: {dr.DriveFormat}\n";
                    output += $"  Available space to current user:{dr.AvailableFreeSpace} bytes\n";
                    output += $"  Total available space: {dr.TotalFreeSpace} bytes\n";
                    output += $"  Total size of drive: {dr.TotalSize} bytes\n";
                }
            }
            return output;
        }
    }
}
