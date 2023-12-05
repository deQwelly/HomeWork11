using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace HomeWork11_2_
{
    public enum BankAccountType { current, saving }
    public class BankAccount
    {
        private static ulong base_number = 0;
        private ulong number;
        private double balance;
        private BankAccountType type;
        private Queue<BankTransaction> accountTransactions = new Queue<BankTransaction>();
        private Hashtable accounts = new Hashtable();

        /// <summary>
        /// Конструктор, заполняющий поле баланс банковского счета
        /// </summary>
        /// <param name="balance"></param>
        internal BankAccount(double balance)
        {
            this.balance = balance;
            type = BankAccountType.current;
            base_number++;
            number = base_number;
            accounts.Add(number, this);
            DumpToScreen();
        }

        /// <summary>
        /// Конструктор, заполняющий поле тип банковского счета
        /// </summary>
        /// <param name="type"></param>
        internal BankAccount(BankAccountType type)
        {
            this.type = type;
            balance = 0;
            base_number++;
            number = base_number;
            accounts.Add(number, this);
            DumpToScreen();
        }

        /// <summary>
        /// Конструктор, заполняющий поля баланс и тип банковского счета
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="type"></param>
        internal BankAccount(double balance, BankAccountType type)
        {
            this.balance = balance;
            this.type = type;
            base_number++;
            number = base_number;
            accounts.Add(number, this);
            DumpToScreen();
        }

        /// <summary>
        /// Базовый конструктор класса BankAccount
        /// </summary>
        internal BankAccount()
        {
            base_number++;
            number = base_number;
            accounts.Add(number, this);
            balance = 0;
            type = BankAccountType.current;
            DumpToScreen();
        }

        public ulong Number
        {
            get
            {
                return number;
            }
        }

        public double Balance
        {
            get
            {
                return balance;
            }
        }

        public BankAccountType Type
        {
            get
            {
                return type;
            }
        }

        public void AccountTransactions()
        {
            foreach (BankTransaction i in accountTransactions)
            {
                Console.WriteLine($"Дата: {i.DateTransaction}\t | Сумма: {i.SumTransaction}");
            }
        }

        /// <summary>
        /// Повзволяет снять деньги со счета
        /// </summary>
        /// <param name="sum"></param>
        public void TakeSomeMoney(double sum)
        {
            if (sum >= 0)
            {
                try
                {
                    checked
                    {
                        sum = Math.Round(sum, 2);
                        double temp = balance - sum;
                        if (temp > 0)
                        {
                            balance = temp;
                            accountTransactions.Enqueue(new BankTransaction(-sum));
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно средств");
                        }
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Нельзя списать такую большую сумму");
                }
            }
            else
            {
                Console.WriteLine("Списание не может быть отрицательным");
            }
        }

        /// <summary>
        /// Вносит деньги на счет
        /// </summary>
        /// <param name="sum"></param>
        public void DepositSomeMoney(double sum)
        {
            if (sum >= 0)
            {
                try
                {
                    checked
                    {
                        sum = Math.Round(sum, 2);
                        balance += sum;
                        accountTransactions.Enqueue(new BankTransaction(sum));
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Нельзя внести такую большую сумму");
                }
            }
            else
            {
                Console.WriteLine("Пополнение не может быть отрицательным");
            }
        }

        /// <summary>
        /// Переводит на счет указанную сумму из указанного счета
        /// </summary>
        /// <param name="transfer_account"></param>
        /// <param name="sum"></param>
        public void TransferToThisAccount(BankAccount transfer_account, double sum)
        {
            if (sum >= 0)
            {
                try
                {
                    checked
                    {
                        if (transfer_account.balance >= sum)
                        {
                            transfer_account.balance -= sum;
                            balance += sum;
                            accountTransactions.Enqueue(new BankTransaction(sum));
                            transfer_account.accountTransactions.Enqueue(new BankTransaction(-sum));
                        }
                        else
                        {
                            Console.WriteLine("На счете недостаточно средств");
                        }
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Нельзя перевести такую большую сумму");
                }
            }
            else
            {
                Console.WriteLine("Перевод не может быть отрицательным");
            }
        }

        /// <summary>
        /// Очередь транзакций записывает в текстовый файл Transactions
        /// </summary>
        public void Dispose()
        {
            while (accountTransactions.Count != 0)
            {
                var temp = accountTransactions.Dequeue();
                File.AppendAllText("Transactions.txt", $"Дата: {temp.DateTransaction}\t| Сумма: {temp.SumTransaction}\n");
            }
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Операция сравнения двух счетов по номеру
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is BankAccount)
            {
                BankAccount account = (BankAccount)obj;
                if (account.Number == Number)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Number}, {Balance}, {Type}";
        }

        public static bool operator ==(BankAccount a, object b)
        {
            if (b is BankAccount)
            {
                BankAccount bAccount = (BankAccount)b;
                if (a.Equals(bAccount))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(BankAccount a, object b)
        {
            if (b is BankAccount)
            {
                BankAccount bAccount = (BankAccount)b;
                if (a.Equals(bAccount))
                {
                    return false;
                }
            }
            return true;
        }

        [Conditional("DEBUG_ACCOUNT")]
        public void DumpToScreen()
        {
            Console.WriteLine(ToString());
        }
    }
}
