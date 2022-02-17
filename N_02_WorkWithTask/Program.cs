using System.Threading.Channels;

namespace N_02_WorkWithTask;

// https://metanit.com/sharp/tutorial/12.2.php
// 
// Работа с классом Task

class Program
{
    public static void Main()
    {
        // InnerTasks_NotAttached();
        // InnerTasks_Attached();
        
        // ArrayOfTask();
        // ArrayOfTask_FactoryExample();
        // ArrayOfTask_ForExample();
        // ArrayOfTask_WaitAll();
        
        TaskResult();
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

    /// <summary>
    /// Массив задач
    /// </summary>
    private static void ArrayOfTask()
    {
        Task[] tasks = new Task[3]
        {
            new Task(() => Console.WriteLine("First Task")),
            new Task(() => Console.WriteLine("Second Task")),
            new Task(() => Console.WriteLine("Third Task"))
        };
        
        foreach (var t in tasks)
            t.Start();
        
        // пока без ожидания
    }

    /// <summary>
    /// Массив задач - Создание через фабрику
    /// </summary>
    private static void ArrayOfTask_FactoryExample()
    {
        Task[] tasks = new Task[3];

        int j = 1;
        for (int i = 0; i < tasks.Length; i++)
            tasks[i] = Task.Factory.StartNew(() => Console.WriteLine($"Task {j++}"));
        
        // так же без ожидания
    }

    /// <summary>
    /// Пример с использованием цикла for
    /// </summary>
    private static void ArrayOfTask_ForExample()
    {
        Task[] tasks = new Task[3];
        for (var i = 0; i < tasks.Length; i++)
        {
            tasks[i] = new Task(() =>
            {
                Console.WriteLine("start");
                Thread.Sleep(1000);
                Console.WriteLine("end");
            });
            tasks[i].Start();
        }

        Console.WriteLine("end od main");
    }

    /// <summary>
    /// Ждем завершения всех задач в массиве
    /// </summary>
    private static void ArrayOfTask_WaitAll()
    {
        Task[] tasks = new Task[3];
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Task{i} finished");
            });
            tasks[i].Start();
        }

        // Ждем пока все задачи завершатся (только потом продолжаем)
        Task.WaitAll(tasks);

        Console.WriteLine("End of Main");
    }

    /// <summary>
    /// Результат задачи
    /// </summary>
    private static void TaskResult()
    {
        // Числа для сложения
        int n1 = 4, n2 = 5;
        
        // Task<int> - int тип возвращаемого задачей результата
        Task<int> sumTask = new Task<int>(() => Sum(n1, n2));
        sumTask.Start();

        int result = sumTask.Result;
        Console.WriteLine($"{n1} + {n2} = {result}"); // 4 + 5 = 9
    }

    private static int Sum(int a, int b) => a + b;
} 