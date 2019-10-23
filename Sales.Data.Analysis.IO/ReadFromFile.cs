using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sales.Data.Analysis.IO
{
    public class ReadFromFile : FileBase
    {
        public string[] GetFiles(string folder)
        {
            string path = $@"{Directory.GetCurrentDirectory()}\{folder}";
            if (!Directory.Exists(path))
                return null;

            return Directory.GetFiles(path);
        }

        public List<string> ReadAllLines(string fileName)
        {
            if (!IsValidFileName(fileName))
                throw new ArgumentException("Nome do arquivo inválido.");

            if (!File.Exists(fileName))
                throw new FileNotFoundException("Arquivo não existe.");

            return File.ReadAllLines(fileName).ToList();
        }
    }
}
