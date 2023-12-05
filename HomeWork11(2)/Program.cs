#define DEBUG_ACCOUNT
using HomeWork11_2_.Classes;
using HouseBuildingLibruary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///Упражнение 14.1
            Console.WriteLine("Использование предопределенного условного атрибута для условного выполнения кода");
            BankAccount account = new BankAccount(BankAccountType.current);
            account.DumpToScreen();

            ///Упражнение 14.2
            Console.WriteLine("\nУпражнение 14.2: Создать пользовательский атрибут DeveloperInfoAttribute");

            Type type = typeof(Rational);
            object[] attributes = type.GetCustomAttributes(false);

            foreach (object attribute in attributes)
            {
                if (attribute is DeveloperInfoAttribute devInfo)
                {
                    Console.WriteLine(devInfo);
                }
            }

            ///Домашнее задание 14.1
            Console.WriteLine("\nДомашнее задание 14.1: Создать пользовательский атрибут для класса из домашнего задания 13.1.\n" +
                "Атрибут позволяет хранить в метаданных класса имя разработчика и название организации.");

            type = typeof(House);
            attributes = type.GetCustomAttributes(false);

            foreach (object attribute in attributes)
            {
                if (attribute is DevAndOrgInfoAttribute devAndOrjInfo)
                {
                    Console.WriteLine(devAndOrjInfo);
                }
            }
        }
    }
}
