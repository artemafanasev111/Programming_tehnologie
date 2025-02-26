using System;

namespace Seminasr1
{
    class Program
    {
        // Метод вычисляет сумму четных цифр в числах от 1 до 100
        // Например: в числе 123 будут учитываться только 2
        static int Sum()        
        {
            int sum_numbers = 0;
            for(int i = 1; i <= 100; i++)
            {
                // Получаем абсолютное значение числа
                int tmp = Math.Abs(i);
                while (tmp > 0)
                {
                    // Проверяем, является ли цифра четной
                    if (tmp % 2 == 0)
                    {
                        sum_numbers += tmp % 10;
                    }
                    tmp /= 10;
                }
            }
            return sum_numbers;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Sum());
        }
    }
}