using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB013
{
    public static class SVYXFileInfo
    {
        public static string GetFileInfo(string path)
        {
            string output = "";
            var inf = new FileInfo(path);
            output += $"File Name: {inf.Name}\n";
            output += $"Расширение файла: {inf.Extension}\n";
            output += $"Размер фалйа: {inf.Length} bytes\n";
            output += $"Way: {inf.DirectoryName}\n";
            output += $"Date of create {inf.CreationTime}\n";
            output += $"Last change: {inf.LastWriteTime}\n";
            return output;
        }
    }
}
