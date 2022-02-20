namespace N_04_Class_Parallel;

/// <summary>
/// Пример использования Parallel.ForEach
/// </summary>
public class Parallel_ForEach_Example
{
    public static void Start()
    {
        List<int> intList = new List<int> { 1, 3, 5, 8 };

        ParallelLoopResult result = Parallel.ForEach<int>(intList, Square);
    }

    private static void Square(int n)
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        
        Thread.Sleep(3000);
        
        Console.WriteLine($"Квадрат числа {n} равен {n * n}");
    }
}