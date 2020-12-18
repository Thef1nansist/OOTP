using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace OOP_LAB013
{
    public static class SVYDirInfo
    {
        public static string GetDirInfo(string path)
        {
            string output = "";
            var infofdir = new DirectoryInfo(path);
            output += $"Count of files: {infofdir.GetFiles().Length}\n";
            output += $"Data of create: {infofdir.CreationTime}\n";
            output += $"count of poddir: {infofdir.GetDirectories().Length}";
            output += $"  Parent: {infofdir.Parent}\n";
            return output;
        }
    }
}
