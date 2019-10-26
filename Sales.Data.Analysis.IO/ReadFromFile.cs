using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sales.Data.Analysis.IO
{
    public class ReadFromFile
    {
        private readonly IDirectoryFile _directoryFile;

        public ReadFromFile(IDirectoryFile directoryFile)
        {
            _directoryFile = directoryFile;
        }

        public string[] GetFiles(string folder)
        {
            string path = $@"{_directoryFile.GetCurrentDirectory()}\{folder}";
            if (!_directoryFile.DirectoryExists(path))
                return null;

            return _directoryFile.GetFiles(path);
        }

        public List<string> ReadAllLines(string fileName)
        {
            if (!_directoryFile.IsValidFileName(fileName))
                throw new ArgumentException("Nome do arquivo inválido.");

            if (!_directoryFile.FileExists(fileName))
                throw new FileNotFoundException("Arquivo não existe.");

            return _directoryFile.ReadAllLines(fileName).ToList();
        }
    }
}
