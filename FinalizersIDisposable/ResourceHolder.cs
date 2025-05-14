namespace FinalizersIDisposable
{
    class ResourceHolder : IDisposable
    {
        private bool _disposed = false;
        private string _name;

        public ResourceHolder(string name)
        {
            _name = name;
            Console.WriteLine($"Создан объект: {_name}");
        }

        ~ResourceHolder()
        {
            Console.WriteLine($"Финализатор вызван: {_name}");
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Console.WriteLine($"Dispose вызван: {_name}");
                _disposed = true;

                GC.SuppressFinalize(this);
            }
        }

        public void EnableFinalizerAgain()
        {
            if (_disposed)
            {
                Console.WriteLine($"ReRegisterForFinalize: {_name}");
                GC.ReRegisterForFinalize(this);
                _disposed = false;
            }
        }
    }
}
