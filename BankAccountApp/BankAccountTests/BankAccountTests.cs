using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountApp;
using System;

namespace BankAccountTests
{
    [TestClass]
    public class BankAccountTests
    {
        [DataTestMethod]
        [DataRow("John Doe", 1000, 200, 800)]
        [DataRow("Jane Smith", 500, 100, 400)]
        [DataRow("Alice Johnson", 300, 50, 250)]
        public void Debit_ValidAmount_UpdatesBalance(string customerName, int initialBalance, int debitAmount, int expectedBalance)
        {
            var account = new BankAccount(customerName, initialBalance);

            account.Debit(debitAmount);

            Assert.AreEqual(expectedBalance, account.Balance);
        }

        [TestMethod]
        public void Debit_InsufficientFunds_ThrowsException()
        {
            var account = new BankAccount("Bob Brown", 100);

            try
            {
                account.Debit(150);
                Assert.Fail("Expected InvalidOperationException was not thrown.");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Insufficient funds", ex.Message);
            }
        }

        [DataTestMethod]
        [DataRow("John Doe", 1000, 200, 1200)]
        [DataRow("Jane Smith", 500, 100, 600)]
        [DataRow("Alice Johnson", 300, 50, 350)]
        public void Credit_ValidAmount_UpdatesBalance(string customerName, int initialBalance, int creditAmount, int expectedBalance)
        {
            var account = new BankAccount(customerName, initialBalance);

            account.Credit(creditAmount);

            Assert.AreEqual(expectedBalance, account.Balance);
        }

        [DataTestMethod]
        [DataRow("John Doe", 1000, 200, 800)]
        [DataRow("Jane Smith", 500, 100, 400)]
        [DataRow("Alice Johnson", 300, 50, 250)]
        public void Withdraw_ValidAmount_UpdatesBalance(string customerName, int initialBalance, int withdrawAmount, int expectedBalance)
        {
            var account = new BankAccount(customerName, initialBalance);

            account.Withdraw(withdrawAmount);

            Assert.AreEqual(expectedBalance, account.Balance);
        }
    }
}