namespace N_03_continationTask;

// https://metanit.com/sharp/tutorial/12.3.php
//
// Задачи продолжения

class Program
{
    public static void Main()
    {
        // Task_ContinueWith();
        // ContinueWith_WithResultParam();
        TaskChain();
    }

    /// <summary>
    /// Использование метода ContinueWith
    /// </summary>
    private static void Task_ContinueWith()
    {
        // Первая задача в цепочке
        Task task1 = new Task(() =>
        {
            Console.WriteLine($"Id задачи: {Task.CurrentId}");
        });

        // Вторая задача в цепочке - выполняется после task1
        Task task2 = task1.ContinueWith(PrintTask);
        
        // Запускаем первую задачу
        task1.Start();

        // Ждем завершения второй задачи
        task2.Wait();

        Console.WriteLine("End of Main");
    }

    /// <summary>
    /// Метод продолжения
    /// </summary>
    /// <param name="previousTask">Предыдущая задача</param>
    private static void PrintTask(Task previousTask)
    {
        Console.WriteLine($"Id задачи: {Task.CurrentId}");
        Console.WriteLine($"Id предыдущей задачи: {previousTask.Id}");
    }

    /// <summary>
    /// Передача результата как параметра следующей задачи
    /// </summary>
    private static void ContinueWith_WithResultParam()
    {
        // Первая задача
        Task<int> sumTask = new Task<int>(() => Sum(4, 5));

        // Задача продолжения
        Task printTask = sumTask.ContinueWith(task => PrintResult(task.Result));
        
        sumTask.Start();

        // ждем окончания второй задачи
        printTask.Wait();

        Console.WriteLine("Конец Main");
    }

    // метод выполняет расчеты
    private static int Sum(int a, int b) => a + b;
    // метод принимает результат расчетов
    private static void PrintResult(int sum) => Console.WriteLine($"Sum: {sum}");

    private static void TaskChain()
    {
        Task task1 = new Task(() => Console.WriteLine($"Current Task: {Task.CurrentId}"));

        Task task2 = task1.ContinueWith(t => Console.WriteLine($"Current Task: {Task.CurrentId} Previous Task: {t.Id}"));

        Task task3 = task2.ContinueWith(t => Console.WriteLine($"Current Task: {Task.CurrentId} Previous Task: {t.Id}"));

        Task task4 = task3.ContinueWith(t => Console.WriteLine($"Current Task: {Task.CurrentId} Previous Task: {t.Id}"));
        
        // Запускаем первую задачу
        task1.Start();

        // Ждем последнюю задачу
        task4.Wait();

        Console.WriteLine("Конец Main");
    }
}