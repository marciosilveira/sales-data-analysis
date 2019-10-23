using System.IO;

namespace Sales.Data.Analysis.IO
{
    public class WriteTextFile : FileBase
    {
        public void WriteText(string path, string fileName, string contents, bool overrideFile = false)
        {
            if (!IsValidFileName(fileName))
                return;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (overrideFile)
                File.WriteAllText($@"{path}\{fileName}", contents);
            else
                File.AppendAllText($@"{path}\{fileName}", contents);
        }
    }
}
