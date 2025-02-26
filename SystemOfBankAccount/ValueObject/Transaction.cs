using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOfBankAccount.ValueObject
{
    // Структура для хранения информации о банковской транзакции
    struct Transaction
    {
        // Сумма транзакции
        public decimal Amount { get; }

        // Дата проведения транзакции
        public DateTime Date { get; }

        // Примечание к транзакции
        public string Note { get; }

        // Конструктор для создания новой транзакции
        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Note = note;
        }
    }
}