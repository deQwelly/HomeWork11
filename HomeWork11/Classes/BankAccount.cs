using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace HomeWork11
{
    public enum BankAccountType { current, saving }
    public class BankAccount
    {
        public BankTransaction this[int index]
        {
            get
            {
                return accountTransactions[index];
            }
            set
            {
                accountTransactions[index] = value;
            }

        }

        private static ulong base_number = 0;
        private ulong number;
        private double balance;
        private string accountHolder;
        private BankAccountType type;

        private List<BankTransaction> accountTransactions = new List<BankTransaction>();
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
        }

        /// <summary>
        /// Базовый конструктор класса BankAccount
        /// </summary>
        internal BankAccount()
        {
            base_number++;
            number = base_number;
            accounts.Add(number, this);
        }

        public ulong Number { get; }

        public double Balance { get; }

        public string AccountHolder { get; set; }

        public BankAccountType Type { get; }

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
                            accountTransactions.Add(new BankTransaction(-sum));
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
                        accountTransactions.Add(new BankTransaction(sum));
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
                            accountTransactions.Add(new BankTransaction(sum));
                            transfer_account.accountTransactions.Add(new BankTransaction(-sum));
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
                var temp = accountTransactions[accountTransactions.Count - 1];
                File.AppendAllText("Transactions.txt", $"Дата: {temp.DateTransaction}\t| Сумма: {temp.SumTransaction}\n");
                accountTransactions.Remove(temp);
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
    }
}
