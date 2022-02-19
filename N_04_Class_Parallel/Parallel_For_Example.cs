namespace N_04_Class_Parallel;

public class Parallel_For_Example
{
    public static void Start()
    {
        Parallel.For(1, 5, Square);
    }

    private static void Square(int n)
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        
        Thread.Sleep(3000);
        
        Console.WriteLine($"Квадрат числа {n} равен {n * n}");
        
    }
}