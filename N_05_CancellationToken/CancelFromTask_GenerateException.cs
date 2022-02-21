namespace N_05_CancellationToken;

/// <summary>
/// Пример отмены задачи с помощью генерации исключения
/// </summary>
public class CancelFromTask_GenerateException
{
    public static void Start()
    {
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token = cancelTokenSource.Token;

        Task task = new Task(() =>
        {
            for (int i = 1; i < 10; i++)
            {
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested(); // генерация исключения на отмену задачи

                Console.WriteLine($"Начало расчета - {i}");
                
                Thread.Sleep(500);

                Console.WriteLine($"Квадрат числа {i} равен {i * i}");
            }
        }, token); // добавляем в задачу токен

        try
        {
            task.Start();

            Thread.Sleep(2000); // задержка перед отменой

            cancelTokenSource.Cancel(); // отмена задания
        }
        catch (AggregateException aggEx)
        {
            foreach (Exception ex in aggEx.InnerExceptions)
            {
                if (ex is TaskCanceledException)
                    Console.WriteLine("Операция прервана");
                else
                    Console.WriteLine(ex.Message);
            }
        }
        finally
        {
            cancelTokenSource.Dispose();
        }
        
        Thread.Sleep(2000); // Ждем смены статуса

        Console.WriteLine($"Task status: {task.Status}"); // Task status: Canceled
    }
}