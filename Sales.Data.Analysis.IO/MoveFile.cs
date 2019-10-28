using System.IO;

namespace Sales.Data.Analysis.IO
{
    public class MoveFile
    {
        private readonly IDirectoryFile _directoryFile;

        public MoveFile(IDirectoryFile directoryFile)
        {
            _directoryFile = directoryFile;
        }

        public void Move(string sourceFileName, string folderMove)
        {
            string pathOut = $@"{_directoryFile.GetCurrentDirectory()}\{folderMove}";
            if (!_directoryFile.DirectoryExists(pathOut))
                _directoryFile.CreateDirectory(pathOut);

            _directoryFile.FileMove(sourceFileName, Path.Combine(pathOut, Path.GetFileName(sourceFileName)));
        }
    }
}
