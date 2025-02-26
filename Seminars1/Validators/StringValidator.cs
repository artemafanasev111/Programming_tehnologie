using System;

namespace Seminasr1.Validators
{
    public class StringValidator
    {
        // Проверяет строку на валидность:
        // - не должна быть пустой или состоять из пробелов
        // - должна содержать только буквы
        public static bool Validate(string Value)
        {
            if (string.IsNullOrWhiteSpace(Value))
                return false;

            // Проверяем каждый символ в строке
            foreach (char c in Value)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            
            return true;
        }
    }
}