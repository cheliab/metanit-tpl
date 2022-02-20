namespace N_04_Class_Parallel;

/// <summary>
/// Пример выхода из цикла
/// </summary>
public class Parallel_Break_Example
{
    public static void Start()
    {
        ParallelLoopResult result = Parallel.For(1, 10, Square);
        if (!result.IsCompleted)
            Console.WriteLine($"Выполнение цикла завершено на итерации {result.LowestBreakIteration}");
    }

    private static void Square(int n, ParallelLoopState pls)
    {
        if (n == 5)
            pls.Break();

        Console.WriteLine($"Начато выполнение чикла {n}");
        
        Thread.Sleep(3000);
        
        Console.WriteLine($"Квадрат числа {n} равен {n * n}");
    }
}