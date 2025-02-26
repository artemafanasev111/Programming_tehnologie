using System;
using Seminasr1.Validators;

namespace Seminasr1
{
    public class Human
    {
        // Автоматические свойства с приватным сеттером
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public DateTime Birthday { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        // Вычисляемое свойство, возвращающее полное имя
        public string FullName => $"{FirstName} {LastName}";

        // Конструктор класса с проверкой всех входных параметров
        public Human(int height, int weight, DateTime birthday, string firstName, string lastName)
        {
            // Проверяем корректность роста
            if (!IntValidator.Validate(height))
                throw new ArgumentException("Некорректное значение роста");

            // Проверяем корректность веса
            if (!IntValidator.Validate(weight))
                throw new ArgumentException("Некорректное значение веса");

            // Проверяем, что дата рождения не в будущем
            if (birthday > DateTime.Now)
                throw new ArgumentException("Дата рождения не может быть в будущем");

            // Проверяем корректность имени
            if (!StringValidator.Validate(firstName))
                throw new ArgumentException("Некорректное имя");

            // Проверяем корректность фамилии
            if (!StringValidator.Validate(lastName))
                throw new ArgumentException("Некорректная фамилия");

            Height = height;
            Weight = weight;
            Birthday = birthday;
            FirstName = firstName;
            LastName = lastName;
        }

        // Методы для изменения параметров человека
        // с соответствующей валидацией
        public bool ChangeHeight(int height)
        {
            if (IntValidator.Validate(height))
            {
                Height = height;
                return true;
            }
            return false;
        }

        public bool ChangeWeight(int weight)
        {
            if (IntValidator.Validate(weight))
            {
                Weight = weight;
                return true;
            }
            return false;
        }

        public bool ChangeFirstName(string firstName)
        {
            if (StringValidator.Validate(firstName))
            {
                FirstName = firstName;
                return true;
            }
            return false;
        }

        public bool ChangeLastName(string lastName)
        {
            if (StringValidator.Validate(lastName))
            {
                LastName = lastName;
                return true;
            }
            return false;
        }
    }
}