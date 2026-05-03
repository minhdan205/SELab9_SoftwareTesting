using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    public class BankAccount
    {
        public string CustomerName { get; private set; }
        public decimal Balance { get; private set; }

        public BankAccount(string customerName, decimal initialBalance)
        {
            CustomerName = customerName;
            Balance = initialBalance;
        }

        public void Debit(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            Balance -= amount;
        }

        public void Credit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Debit(amount);
        }
    }
}