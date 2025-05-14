namespace MemoryLeak
{
    class Subscriber
    {
        private string _name;

        public Subscriber(string name)
        {
            _name = name;
        }

        public void Handler(object sender, EventArgs e)
        {
            Console.WriteLine($"{_name} получил событие");
        }

        ~Subscriber()
        {
            Console.WriteLine($"Финализатор вызван для {_name}");
        }
    }
}
