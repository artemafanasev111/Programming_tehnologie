using System;
using System.Collections.Generic;
using SystemOfBankAccount.ValueObject;

namespace SystemOfBankAccount
{
    // Класс, представляющий банковский счет
    class BankAccount
    {
        // Список всех транзакций по счету
        private List<Transaction> _allTransaction = new List<Transaction>(); 

        // Начальное значение для генерации номеров счетов
        private static int a_accountNumberSeed = 1000000000;

        // Номер банковского счета
        public NumberOfBankAccount Number { get; }

        // Владелец счета
        public string Owner { get; set; }

        // Текущий баланс счета (вычисляется на основе всех транзакций)
        public decimal Balance 
        { 
            get
            {
                decimal balance = 0;
                foreach(var item in _allTransaction)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        // Конструктор для создания нового банковского счета
        public BankAccount(string owner, decimal InitialBalance)
        {
            Number = new NumberOfBankAccount(a_accountNumberSeed);
            a_accountNumberSeed++;
            Owner = owner;
            MakeDeposit(InitialBalance, DateTime.Now, "efsef");
        }

        // Метод для внесения денег на счет
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive.");

            var deposit = new Transaction(amount, date, note);
            _allTransaction.Add(deposit);
        }

        // Метод для снятия денег со счета
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive.");
            
            if(Balance - amount < 0)
                throw new InvalidOperationException("Not sufficient rubls for this");

            var deposit = new Transaction(-amount, date, note);
            _allTransaction.Add(deposit);
        }
    }
}