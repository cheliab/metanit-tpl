namespace N_05_CancellationToken;

// https://metanit.com/sharp/tutorial/12.5.php
//
// Отмена задач и параллельных операций. CancellationToken

class Program
{
    public static void Main()
    {
        SoftExitFromTask_WithoutException.Start();
    }
} 