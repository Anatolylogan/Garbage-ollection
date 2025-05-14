using UsingWeakReference;
class Program
{
    static void Main()
    {
        WeakReference<MyClass> weakRef;

        {
            var obj = new MyClass("TestObject");
            weakRef = new WeakReference<MyClass>(obj);

            Console.WriteLine("Объект создан и слабая ссылка сохранена.");

            obj = null;
        }

        Console.WriteLine("Сильная ссылка удалена. Форсируем сборку мусора...");

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        if (weakRef.TryGetTarget(out MyClass target))
        {
            Console.WriteLine($"Объект ещё жив: {target.Name}");
        }
        else
        {
            Console.WriteLine("Объект был собран GC.");
        }
    }
}
