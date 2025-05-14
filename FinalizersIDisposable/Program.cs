using FinalizersIDisposable;
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Без Dispose ===");
        CreateWithoutDispose();

        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine();

        Console.WriteLine("=== С Dispose ===");
        CreateWithDispose();

        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine();

        Console.WriteLine("=== С ReRegisterForFinalize ===");
        CreateWithReRegister();

        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.ReadLine();
    }

    static void CreateWithoutDispose()
    {
        var obj = new ResourceHolder("Obj1");
    }

    static void CreateWithDispose()
    {
        var obj = new ResourceHolder("Obj2");
        obj.Dispose();
    }

    static void CreateWithReRegister()
    {
        var obj = new ResourceHolder("Obj3");
        obj.Dispose();                  
        obj.EnableFinalizerAgain();     
    }
}