using MemoryLeak;
class Program
{
    static void Main()
    {
        var publisher = new Publisher();
        WeakReference weakRef;

        Console.WriteLine("=== Подписка без отписки ===");
        weakRef = CreateSubscriberAndSubscribe(publisher, "A", unsubscribe: false);

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        Console.WriteLine($"Жив подписчик A: {weakRef.IsAlive}"); 
        Console.WriteLine();

        Console.WriteLine("=== Подписка с отпиской ===");
        weakRef = CreateSubscriberAndSubscribe(publisher, "B", unsubscribe: true);

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        Console.WriteLine($"Жив подписчик B: {weakRef.IsAlive}");
    }

    static WeakReference CreateSubscriberAndSubscribe(Publisher publisher, string name, bool unsubscribe)
    {
        var subscriber = new Subscriber(name);
        EventHandler handler = subscriber.Handler;
        publisher.SomethingHappened += handler;

        var weakRef = new WeakReference(subscriber);

        if (unsubscribe)
        {
            publisher.SomethingHappened -= handler;
        }

        subscriber = null;

        return weakRef;
    }
}
