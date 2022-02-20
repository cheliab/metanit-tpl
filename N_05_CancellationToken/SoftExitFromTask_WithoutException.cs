namespace N_05_CancellationToken;

/// <summary>
/// Пример "мягкого" выхода из задачи, без исключения OperationCanceledException
/// </summary>
public class SoftExitFromTask_WithoutException
{
    public static void Start()
    {
        // Создаем источник токенов и получаем токен
        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token = cancelTokenSource.Token;

        // Создаем задачу и передаем туда токен отмены
        Task task = new Task(() =>
        {
            for (int i = 1; i < 10; i++)
            {
                if (token.IsCancellationRequested) // проверка отмены
                {
                    Console.WriteLine("Операция прервана");
                    return;
                }

                Console.WriteLine($"Начало расчетов для числа {i}");
                
                Thread.Sleep(500);
                
                Console.WriteLine($"Квадрат числа {i} равен {i * i}");
            }
        }, token); // передаем токен отмены
        
        task.Start();
        
        Thread.Sleep(2000); // ждем 2 сек.
        
        cancelTokenSource.Cancel(); // Отменяем выполнение задачи
        
        Thread.Sleep(1000); // Немного ждем (для смены статуса задачи)

        Console.WriteLine($"Task status: {task.Status}");
        
        cancelTokenSource.Dispose(); // Освобождаем все ресурсы в ручную
    }
}