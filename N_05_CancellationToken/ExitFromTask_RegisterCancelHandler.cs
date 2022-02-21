namespace N_05_CancellationToken;

/// <summary>
/// Регистрация обработчика отмены задачи
/// </summary>
public class ExitFromTask_RegisterCancelHandler
{
    public static void Start()
    {
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token = cancelTokenSource.Token;

        Task task = new Task(() =>
        {
            int i = 1;

            token.Register(() =>
            {
                Console.WriteLine("Операция прервана");
                i = 10;
            });

            for (; i < 10; i++)
            {
                Console.WriteLine($"Квадрат числа {i} равен {i * i}");
                Thread.Sleep(500);
            }
        }, token);
        
        task.Start();
        
        Thread.Sleep(1000);

        cancelTokenSource.Cancel();
        
        Thread.Sleep(2000);

        Console.WriteLine($"Task status: {task.Status}");
        
        cancelTokenSource.Dispose();
    }
}