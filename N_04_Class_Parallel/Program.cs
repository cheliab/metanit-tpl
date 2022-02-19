﻿namespace N_04_Class_Parallel;

class Program 
{
    public static void Main()
    {
        UseParallelInvoke();
    }

    /// <summary>
    /// Пример использования метода Parallel.Invoke
    /// Параллельное выполнение нескольких методов
    /// </summary>
    private static void UseParallelInvoke()
    {
        // В методе Invoke выполняется три метода (параллельно)
        Parallel.Invoke(
            Print,
            () =>
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
            },
            () => Square(5)
        );
    }

    private static void Print()
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        Thread.Sleep(3000);
    }

    private static void Square(int n)
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
        Thread.Sleep(3000);
        
        Console.WriteLine($"Результат {n * n}");
    }
}