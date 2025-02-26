using System;
using SystemOfBankAccount;

namespace SystemOfB
{
    /// <summary>
    /// Основной класс программы
    /// </summary>
    class Program
    {
        /// <summary>
        /// Главный метод программы, демонстрирующий работу с банковским счетом
        /// </summary>
        static void Main(string[] args)
        {
            // Создание нового счета с начальным балансом
            var account1 = new BankAccount("Adqwd", 10000);
            
            // Вывод информации о созданном счете
            Console.WriteLine($" Account {account1.Number.Value} was create for {account1.Owner} with {account1.Balance} initial balance.");
            
            // Демонстрация операций со счетом
            account1.MakeDeposit(100m, DateTime.Now, "wefrwer");
            account1.MakeDeposit(2000000m, DateTime.Now, "rrwer");
            account1.MakeWithdrawal(1m, DateTime.Now, "wtwer");
            
            // Вывод итоговой информации о счете
            Console.WriteLine($" Account {account1.Number.Value} was create for {account1.Owner} with {account1.Balance} initial balance.");
        }
    }
}