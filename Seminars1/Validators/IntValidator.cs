namespace Seminasr1.Validators
{
    public class IntValidator
    {
        // Проверяет, является ли число положительным
        // Возвращает true, если число больше 0
        public static bool Validate(int Value)
        {
            return Value > 0;
        }
    }
}