using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfBankAccount.ValueObject
{
    // Структура для хранения номера банковского счета
    // Гарантирует, что номер счета будет 10-значным числом
    struct NumberOfBankAccount
    {
        private int value;
        public int Value { get; set; }

        // Конструктор с проверкой на корректность номера счета
        // Номер должен быть 10-значным числом (от 1000000000 до 9999999999)
        public NumberOfBankAccount(int value)
        {
            if (value < 1000000000 || value >= 10000000000)
                throw new ArgumentOutOfRangeException(nameof(value), "Errror");

            Value = value;
        }
    }
}