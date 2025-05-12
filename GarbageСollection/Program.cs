using GarbageСollection;

class Program
{
    static void Main()
    {
        Console.WriteLine("Создаем объекты...");

        MyObject[] objects = new MyObject[10];

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = new MyObject();
            Console.WriteLine($"Объект[{i}] создан. Поколение: {GC.GetGeneration(objects[i])}");
        }

        Console.WriteLine("Принудительный сбор мусора Gen 0...");
        GC.Collect(0, GCCollectionMode.Forced);
        GC.WaitForPendingFinalizers();

        for (int i = 0; i < objects.Length; i++)
        {
            Console.WriteLine($"Объект[{i}] после GC.Collect(0): Поколение: {GC.GetGeneration(objects[i])}");
        }

        Console.WriteLine("Принудительный сбор мусора всех поколений (Gen 2)...");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        for (int i = 0; i < objects.Length; i++)
        {
            Console.WriteLine($"Объект[{i}] после полной GC.Collect(): Поколение: {GC.GetGeneration(objects[i])}");
        }

        Console.WriteLine("Используем GC.KeepAlive, чтобы сохранить объекты от удаления...");
        foreach (var obj in objects)
        {
            GC.KeepAlive(obj);
        }

        Console.WriteLine("Сборка завершена. Нажмите Enter для выхода.");
        Console.ReadLine();
    }
}
