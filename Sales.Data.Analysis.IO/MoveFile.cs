using System.IO;

namespace Sales.Data.Analysis.IO
{
    public class MoveFile
    {
        public void Move(string sourceFileName, string folderMove)
        {
            string pathOut = $@"{Directory.GetCurrentDirectory()}\{folderMove}";
            if (!Directory.Exists(pathOut))
                Directory.CreateDirectory(pathOut);

            File.Move(sourceFileName, Path.Combine(pathOut, Path.GetFileName(sourceFileName)));
        }
    }
}
