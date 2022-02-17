namespace N_02_WorkWithTask;

class Program
{
    public static void Main()
    {
        // InnerTasks_NotAttached();
        InnerTasks_Attached();
    }

    /// <summary>
    /// Использование вложенных задач (без привязки)
    /// </summary>
    private static void InnerTasks_NotAttached()
    {
        // Создаем внешнюю задачу
        var outerTask = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Outer task staring...");

            // Пример без привязки к родителю
            var innerTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Inner task starting...");
                Thread.Sleep(2000);
                Console.WriteLine("Inner task finished...");
            });

            Console.WriteLine("Outer task ending...");
        });

        outerTask.Wait(); // ожидание завершения внешней задачи

        Console.WriteLine("End of Main");
    }

    /// <summary>
    /// Вложенная задача с привязкой к родителю
    /// </summary>
    private static void InnerTasks_Attached()
    {
        // Внешняя задача
        var outerTask = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Outer task starting...");

            // Вложенная задача
            var innerTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Inner task starting...");
                Thread.Sleep(2000);
                Console.WriteLine("Inner task finished...");
            }, TaskCreationOptions.AttachedToParent); // параметр для прикрепления к родителю
        });

        // Ожидаем завершения внешней задачи (теперь обе задачи выполнятся)
        outerTask.Wait();

        Console.WriteLine("End of Main");
    }
} 