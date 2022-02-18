namespace N_03_continationTask;

// https://metanit.com/sharp/tutorial/12.3.php
//
// Задачи продолжения

class Program
{
    public static void Main()
    {
        Task_ContinueWith();
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
}