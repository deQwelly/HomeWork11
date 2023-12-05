using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11_2_
{
    public class BankAccountFactory
    {
        private static Hashtable accountTable = new Hashtable();

        public BankAccount CreateAccount()
        {
            BankAccount bankAccount = new BankAccount();
            accountTable.Add(bankAccount.Number, bankAccount);
            return bankAccount;
        }

        public ulong CreateAccount(BankAccountType type)
        {
            BankAccount bankAccount = new BankAccount(type);
            accountTable.Add(bankAccount.Number, bankAccount);
            return bankAccount.Number;
        }

        public static void CloseAccount(ulong number)
        {
            if (accountTable.ContainsKey(number))
            {
                accountTable.Remove(number);
                Console.WriteLine($"Счет успешно закрыт");
            }
            else
            {
                Console.WriteLine("Счета с указанным номером не существует");
            }
        }
    }
}
