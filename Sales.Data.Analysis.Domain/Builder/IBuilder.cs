namespace Sales.Data.Analysis.Domain.Builder
{
    public interface IBuilder<out T> where T : class
    {
        T Build();
    }
}
