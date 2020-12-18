using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB013
{

    class Program
    {
        static void Main(string[] args)
        {

            var desctop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var dirPath = Path.Combine(desctop, "SVYInspect");
            var FilePath = Path.Combine(desctop, "SVYInspect", "svydirinfo.txt");
            var copyfilepath = Path.Combine(desctop, "SVYInspect", "svydirinfo_copy.txt");
            var dirPathSec = Path.Combine(desctop, "SVYDirSec");
            var dest = Path.Combine(dirPath, new DirectoryInfo(dirPathSec).Name);
            var zip = Path.Combine(desctop, "Files.zip");
            var dir2 = Path.Combine(desctop, "unarchivedFiles");
            try
            {
                SVYFileManager.CreateDir(dirPath);
                SVYFileManager.CreateFile(FilePath);
                SVYFileManager.CopyFile(FilePath, copyfilepath);
                SVYFileManager.DeleteFile(FilePath);
                SVYFileManager.CreateDir(dirPathSec);
                SVYFileManager.CopyRange(dirPathSec, new DirectoryInfo("C:\\Users\\Vlad\\Downloads").GetFiles(), ".pdf");
                SVYFileManager.ReplaceDir(dirPathSec, dest);
                SVYFileManager.CompressDir(dest, zip);
                SVYFileManager.ExtractDir(zip, dir2);

                var log = new SVYLog();
                var logs = log.ReadLog();
                foreach (var item   in logs.Where(x => x.Date.Day == 18))
                {
                    Console.WriteLine(item.ToString());
                }
                foreach (var item in logs.Where(x => x.Action == "Create"))
                {
                    Console.WriteLine(item.ToString());
                }

                log.ClearLog();
                log.WriteLog(logs.Where(x => x.Action.Contains("Create")));


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            finally
            {
                Directory.Delete(dirPath, true);
                File.Delete(zip);
                Directory.Delete(dir2, true);
                Console.ReadLine();
            }

        }
    }
}
