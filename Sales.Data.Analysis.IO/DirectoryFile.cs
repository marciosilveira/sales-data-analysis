using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Sales.Data.Analysis.IO
{
    [ExcludeFromCodeCoverage]
    public class DirectoryFile : IDirectoryFile
    {
        public string GetCurrentDirectory() => Directory.GetCurrentDirectory();
        public bool IsValidFileName(string fileName) => !string.IsNullOrWhiteSpace(fileName);
        public bool DirectoryExists(string path) => Directory.Exists(path);
        public void CreateDirectory(string path) => Directory.CreateDirectory(path);
        public bool FileExists(string fileName) => File.Exists(fileName);
        public string[] GetFiles(string path) => Directory.GetFiles(path);
        public string[] ReadAllLines(string fileName) => File.ReadAllLines(fileName);
        public void WriteAllText(string path, string contents) => File.WriteAllText(path, contents);
        public void AppendAllText(string path, string contents) => File.AppendAllText(path, contents);
        public void FileMove(string sourceFileName, string destFileName) => File.Move(sourceFileName, destFileName);
    }
}
