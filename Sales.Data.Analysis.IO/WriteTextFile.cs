namespace Sales.Data.Analysis.IO
{
    public class WriteTextFile
    {
        private readonly IDirectoryFile _directoryFile;

        public WriteTextFile(IDirectoryFile directoryFile)
        {
            _directoryFile = directoryFile;
        }

        public void WriteText(string path, string fileName, string contents, bool overrideFile = false)
        {
            if (!_directoryFile.IsValidFileName(fileName))
                return;

            if (!_directoryFile.DirectoryExists(path))
                _directoryFile.CreateDirectory(path);

            if (overrideFile)
                _directoryFile.WriteAllText($@"{path}\{fileName}", contents);
            else
                _directoryFile.AppendAllText($@"{path}\{fileName}", contents);
        }
    }
}
