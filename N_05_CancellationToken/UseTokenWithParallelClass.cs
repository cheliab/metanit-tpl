namespace N_05_CancellationToken;

public class UseTokenWithParallelClass
{
    public static void Start()
    {
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token = source.Token;

        Task.Run(() =>
        {
            Thread.Sleep(500);
            source.Cancel();
        });

        try
        {
            Parallel.ForEach(new List<int> {1, 2, 3, 4, 5}, new ParallelOptions {CancellationToken = token}, Square);
        }
        catch (OperationCanceledException e)
        {
            Console.WriteLine("Операция прервана");
        }
        finally
        {
            source.Dispose();
        }
    }

    private static void Square(int n)
    {
        Thread.Sleep(3000);
        Console.WriteLine($"Квадрат числа {n} равен {n * n}");
    }
}