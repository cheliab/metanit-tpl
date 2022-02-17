namespace N_01_TaskClass;

// https://metanit.com/sharp/tutorial/12.1.php
// 
// Задачи и класс Task

public class Program
{
    public static void Main()
    {
        // SimpleExample();
        // WaitTasks();
        // WaitIsBlockMainThread();
        RunTaskSynchronously();
    }

    /// <summary>
    /// Супер простой пример создания заданий
    /// </summary>
    private static void SimpleExample()
    {
        // Простое создание задания
        Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
        task1.Start(); // запуск задания

        // Создание и запуск через фабрику
        Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));
        
        // Использование статического метода Run (создание + запуск)
        Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));
        
        // пример без ожидания задач
        // чисто процесс создания
    }

    /// <summary>
    /// Пример ожидания заданий
    /// </summary>
    private static void WaitTasks()
    {
        Task task1 = new Task(() => Console.WriteLine("Task1 is execute"));
        task1.Start();

        Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));

        Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));

        // Ожидаем завершения заданий
        task1.Wait();
        task2.Wait();
        task3.Wait();
    }

    /// <summary>
    /// Метод Wait блокирует вызвавший поток, пока задача не завершится
    /// Доп. пример
    /// </summary>
    private static void WaitIsBlockMainThread()
    {
        Console.WriteLine("Main Start");

        Task task1 = new Task(() =>
        {
            Console.WriteLine("Task Start");
            Thread.Sleep(3000);
            Console.WriteLine("Task End");
        });
        task1.Start();

        // Ожидаем завершения задачи
        task1.Wait(); // вызывающий поток так же будет заблокирован на 3 сек.

        Console.WriteLine("Main End");
    }

    /// <summary>
    /// Синхронный запуск задачи
    /// </summary>
    private static void RunTaskSynchronously()
    {
        Console.WriteLine("Main start");

        Task task1 = new Task(() =>
        {
            Console.WriteLine("Task start");
            Thread.Sleep(3000);
            Console.WriteLine("Task end");
        });
        
        // Запускаем задачу синхронно
        task1.RunSynchronously();

        // Тест будет выведен только после синхронного выполнения задания
        Console.WriteLine("Main end");
    }

    /// <summary>
    /// Некоторые из основных свойств задания
    /// </summary>
    private static void TaskProperties()
    {
        Task task1 = new Task(() =>
        {
            Console.WriteLine($"Task{Task.CurrentId} start");
            Thread.Sleep(2000);
            Console.WriteLine($"Task{Task.CurrentId} end");
        });
        task1.Start(); // Запускаем задачу

        Console.WriteLine($"task1 Id: {task1.Id}");
        Console.WriteLine($"task1 is Completed: {task1.IsCompleted}");
        Console.WriteLine($"task1 Status: {task1.Status}");

        task1.Wait();
    }
}