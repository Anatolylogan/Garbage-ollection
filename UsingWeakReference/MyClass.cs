namespace UsingWeakReference
{
    class MyClass
    {
        public string Name { get; }

        public MyClass(string name)
        {
            Name = name;
        }

        ~MyClass()
        {
            Console.WriteLine($"Финализатор вызван для {Name}");
        }
    }
}
