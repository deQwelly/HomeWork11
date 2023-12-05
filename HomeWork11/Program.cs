using HomeWork11.Classes;
using HouseBuildingLibruary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///Упражнение 13.1
            Console.WriteLine("Упражнение 12.1: Из класса банковский счет удалить методы, возвращающие значения полей\n" +
                "номер счета и тип счета, заменить эти методы на свойства только для чтения.\n" +
                "Добавить свойство для чтения и записи типа string для отображения поля держатель банковского счета.\n" +
                "Изменить класс BankTransaction, созданный для хранений финансовых операций со счетом,\n" +
                "заменить методы доступа к данным на свойства для чтения.");
            BankAccount account  = new BankAccount(BankAccountType.current);
            account.AccountHolder = "Егор";
            Console.WriteLine($"{account.AccountHolder}\t{account.Number}\t{account.Type}\t{account.Balance}");

            ///Упражнение 13.2
            Console.WriteLine("\nУпражнение 13.2: Добавить индексатор в класс банковский счет для получения доступа к любому объекту BankTransaction.");
            account.DepositSomeMoney(1000);
            account.TakeSomeMoney(250);
            Console.WriteLine($"{account[0]}\n{account[1]}");

            ///Домашнее задание 13.1
            Console.WriteLine("\nДомашнее задание 13.1: В классе здания из домашнего задания 7.1\n" +
                "все методы для заполнения и получения значений полей заменить на свойства. Написать тестовый пример.");
            House h1 = new House(100, 50, 75, 2);
            Console.WriteLine($"{h1.Number}\t{h1.Heigh}\t{h1.Appartments}\t{h1.Entrances}");

            ///Домашнее задание 13.2
            Console.WriteLine("\nДомашнее задание 13.2: Создать класс для нескольких зданий. Поле класса – массив на 10 зданий.\n" +
                "В классе создать индексатор, возвращающий здание по его номеру.");
            House h2 = new House(100, 50, 75, 2);
            House h3 = new House(100, 50, 75, 2);
            House h4 = new House(100, 50, 75, 2);
            House h5 = new House(100, 50, 75, 2);
            House h6 = new House(100, 50, 75, 2);
            House h7 = new House(100, 50, 75, 2);

            HouseCollection houseComplex1 = new HouseCollection();

            houseComplex1.AddHouse(h1);
            houseComplex1.AddHouse(h2);
            houseComplex1.AddHouse(h3);
            houseComplex1.AddHouse(h4);
            houseComplex1.AddHouse(h5);
            houseComplex1.AddHouse(h6);
            houseComplex1.AddHouse(h7);

            Console.WriteLine($"{houseComplex1[1]}\n{houseComplex1[5]}");
        }
    }
}
