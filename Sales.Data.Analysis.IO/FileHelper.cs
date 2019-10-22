using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sales.Data.Analysis.IO
{
    public static class FileHelper
    {
        public static StreamWriter CreateFile(string path, string fileName, bool overrideFile = false)
        {
            string fullFileName = Path.Combine(path, fileName);

            if (!Directory.Exists(Path.GetDirectoryName(fullFileName)))
                Directory.CreateDirectory(fullFileName);

            FileMode fileMode = overrideFile ? FileMode.Create : FileMode.OpenOrCreate;

            FileStream fileStream = new FileStream(fullFileName, fileMode, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            return streamWriter;
        }

        public static string[] GetFiles(string folder)
        {
            string path = $@"{Directory.GetCurrentDirectory()}\{folder}";
            if (!Directory.Exists(path))
                return null;

            return Directory.GetFiles(path);
        }

        public static List<string> ReadFile(string fileName)
        {
            if (!IsValidFileName(fileName))
                throw new ArgumentException("Nome do arquivo inválido.");

            if (!File.Exists(fileName))
                throw new FileNotFoundException("Arquivo não existe.");

            return File.ReadAllLines(fileName).ToList();
        }

        public static void SaveFile(string fileName, List<string> contents, bool overrideFile = false)
        {
            if (!IsValidFileName(fileName))
                return;

            if (overrideFile)
                File.WriteAllLines(fileName, contents);
            else
                File.AppendAllLines(fileName, contents);
        }

        public static void SaveFile(string fileName, string contents, bool overrideFile = false)
        {
            if (!IsValidFileName(fileName))
                return;

            if (overrideFile)
                File.WriteAllText(fileName, contents);
            else
                File.AppendAllText(fileName, contents);
        }

        public static void SaveFile(string path, string fileName, List<int> contents, bool overrideFile = false)
        {
            if (!IsValidFileName(fileName))
                return;

            StreamWriter file = CreateFile(path, fileName, overrideFile);

            foreach (int num in contents)
            {
                file.WriteLine(num);
            }

            file.Close();
        }

        public static void SaveFile(string path, string fileName, int[] contents, bool overrideFile = false)
        {
            if (!IsValidFileName(fileName))
                return;

            StreamWriter file = CreateFile(path, fileName, overrideFile);

            foreach (int num in contents)
            {
                file.WriteLine(num);
            }

            file.Close();
        }

        private static bool IsValidFileName(string fileName)
        {
            return !string.IsNullOrWhiteSpace(fileName);
        }
    }
}
