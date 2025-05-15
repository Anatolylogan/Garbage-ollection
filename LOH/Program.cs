class Program
{
    static void Main()
    {
        Console.WriteLine("Создаём большой объект (>85 000 байт)...");

        byte[] largeArray = new byte[100_000];

        Console.WriteLine("Поколение объекта: " + GC.GetGeneration(largeArray));
        largeArray = null;

        Console.WriteLine("Удалена сильная ссылка на объект. Запускаем сборку мусора...");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        Console.WriteLine("Сборка мусора завершена. LOH собирается только при полной сборке (Gen 2).");
    }
}

