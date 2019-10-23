namespace Sales.Data.Analysis.IO
{
    public abstract class FileBase
    {
        protected bool IsValidFileName(string fileName) => !string.IsNullOrWhiteSpace(fileName);
    }
}
