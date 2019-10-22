namespace Sales.Data.Analysis.Domain.Builder
{
    public abstract class Builder<T> : IBuilder<T> where T : class, new()
    {
        protected T Instance { get; set; }

        protected Builder()
          : this(null) { }

        protected Builder(T instance)
        {
            if (instance == null)
                instance = CreateInstance();

            Instance = instance;
        }

        private static T CreateInstance() => new T();

        public virtual T CreateResponse()
        {
            return Instance;
        }
        public T Build()
        {
            return CreateResponse();
        }
    }
}
