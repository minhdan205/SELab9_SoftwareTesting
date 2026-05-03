using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountApp;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BankAccountTests
{
    [TestClass]
    public class BankAccountCsvTests
    {
        public static IEnumerable<object[]> GetTestData()
        {
            using var reader = new StreamReader("BankAccountTestData.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            foreach (var record in csv.GetRecords<TestData>())
            {
                yield return new object[]
                {
                    record.CustomerName,
                    record.InitialBalance,
                    record.DebitAmount,
                    record.ExpectedBalance
                };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Debit_CsvData_UpdatesBalance(
            string customerName,
            decimal initialBalance,
            decimal debitAmount,
            string expectedBalance)
        {
            var account = new BankAccount(customerName, initialBalance);

            if (expectedBalance == "Insufficient funds")
            {
                try
                {
                    account.Debit(debitAmount);
                    Assert.Fail("Expected InvalidOperationException was not thrown.");
                }
                catch (InvalidOperationException ex)
                {
                    Assert.AreEqual("Insufficient funds", ex.Message);
                }
            }
            else
            {
                account.Debit(debitAmount);
                Assert.AreEqual(decimal.Parse(expectedBalance), account.Balance);
            }
        }

        public class TestData
        {
            public string CustomerName { get; set; }
            public decimal InitialBalance { get; set; }
            public decimal DebitAmount { get; set; }
            public string ExpectedBalance { get; set; }
        }
    }
}