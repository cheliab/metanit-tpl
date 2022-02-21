namespace N_05_CancellationToken;

/// <summary>
/// Передача токена во внешний метод
/// </summary>
public class CancelFromTask_PassingTokenToExternalMethod
{
    public static void Start()
    {
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token = cancelTokenSource.Token;

        Task task = new Task(() => PrintSquares(token), token);

        try
        {
            task.Start();
            
            Thread.Sleep(1000);
            
            cancelTokenSource.Cancel();

            task.Wait();
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

        Console.WriteLine($"Task status: {task.Status}");
    }

    private static void PrintSquares(CancellationToken token)
    {
        for (int i = 0; i < 10; i++)
        {
            if (token.IsCancellationRequested)
                token.ThrowIfCancellationRequested();

            Console.WriteLine($"Квадрат числа {i} равен {i * i}");
            Thread.Sleep(200);
        }
    }
}