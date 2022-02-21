namespace N_05_CancellationToken;

// https://metanit.com/sharp/tutorial/12.5.php
//
// Отмена задач и параллельных операций. CancellationToken

class Program
{
    public static void Main()
    {
        // CancelFromTask_WithoutException.Start();
        // CancelFromTask_GenerateException.Start();
        // CancelFromTask_RegisterCancelHandler.Start();
        CancelFromTask_PassingTokenToExternalMethod.Start();
    }
} 