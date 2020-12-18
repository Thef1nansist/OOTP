using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.IO.Compression;

namespace OOP_LAB013
{
    public static class SVYFileManager
    {
        private static SVYLog log;

        static SVYFileManager()
        {
            log = new SVYLog();
        }

        public static IEnumerable<string> GetFileSystemInfos(string path)
        {
            var dir = new DirectoryInfo(path);
            List<string> all = new List<string>();
            all.Add("============Список каталогов=============\n");
            foreach(var item in dir.GetDirectories())
            {
                all.Add(item.Name);
                all.Add("==Список подкаталогов==");
                foreach (var it in item.GetDirectories())
                    all.Add(it.Name);
                all.Add(" ");
            }
            all.Add("============Список файлов=============");
            foreach(var item in dir.GetFiles())
            {
                all.Add(item.Name);
                all.Add(" ");
            }
            return all;
        }

        public static void CreateDir(string path)
        {
            if (new DirectoryInfo(path).Exists)
                throw new Exception($"{path} directory alrady exist");
            Directory.CreateDirectory(path);
            log.WriteLog("Create directiry", path);
        }

        public static void CreateFile(string path, string input = " ")
        {
            using(var wr = new StreamWriter(path))
            {
                wr.Write(input);
            }
            log.WriteLog("Create File and write to file", path);
        }

        public static void CopyFile(string filePath, string copyPath, bool overrideFile = false)
        {
            File.Copy(filePath, copyPath, overrideFile);
            log.WriteLog("Copy File", filePath);

        }

        public static void DeleteFile(string filePath)
        {
            File.Delete(filePath);
            log.WriteLog("Create File and write to file", filePath);
        }
        public static void Replace(string sourcePath, string destinationPath, string destinationBackupFileName = "",
            bool ignoreErrors = false)
        {
            File.Replace(sourcePath, destinationPath, destinationBackupFileName, ignoreErrors);
            log.WriteLog("Replace file", destinationPath);
        }

        public static void ReplaceDir(string sourcePath, string destinationPath)
        {
            Directory.Move(sourcePath, destinationPath);
            log.WriteLog("Replace directory", destinationPath);
        }
        public static void CopyRange(string dirPath, FileInfo[] files, string extension, bool overrideFiles = false)
        {
            foreach (var file in files.Where(x => x.Extension == extension))
            {
                File.Copy(file.FullName, Path.Combine(dirPath, file.Name), overrideFiles);
            }

            log.WriteLog("Copy files from path", dirPath);
        }
        public static void Rename(string filePath, string newFileName)
        {
            var newPath = filePath.Replace(Path.GetFileName(filePath), newFileName);

            File.Copy(filePath, newFileName);

            log.WriteLog("Rename", filePath);
        }

        public static void CompressDir(string dirPath, string zipPath)
        {
            ZipFile.CreateFromDirectory(dirPath, zipPath);
            log.WriteLog("Archive directory", dirPath);
        }

        public static void ExtractDir(string zipPath, string extractPath)
        {
            ZipFile.ExtractToDirectory(zipPath, extractPath);
            log.WriteLog("Unarchive directory", zipPath);
        }
    }
}
