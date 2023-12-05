using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork11
{
    public class BankTransaction
    {
        private DateTime dateTransaction;
        private double sumTransaction;

        public BankTransaction(double sumTransaction)
        {
            this.sumTransaction = sumTransaction;
            dateTransaction = DateTime.UtcNow;
        }

        public DateTime DateTransaction
        {
            get
            {
                return dateTransaction;
            }
        }

        public double SumTransaction
        {
            get
            {
                return sumTransaction;
            }
        }

        public override string ToString()
        {
            return $"{dateTransaction} {sumTransaction}";
        }
    }
}
