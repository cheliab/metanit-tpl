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
        WaitIsBlockMainThread();
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
}