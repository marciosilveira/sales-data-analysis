namespace Sales.Data.Analysis.IO
{
    public interface IDirectoryFile
    {
        string GetCurrentDirectory();
        bool IsValidFileName(string fileName);
        bool DirectoryExists(string path);
        void CreateDirectory(string path);
        bool FileExists(string fileName);
        string[] GetFiles(string path);
        string[] ReadAllLines(string fileName);
        void WriteAllText(string path, string contents);
        void AppendAllText(string path, string contents);
        void FileMove(string sourceFileName, string destFileName);
    }
}
