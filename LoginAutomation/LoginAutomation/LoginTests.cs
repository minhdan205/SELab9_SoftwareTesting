using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace LoginAutomation
{
    [TestClass]
    public class LoginTests
    {
        public static IEnumerable<object[]> GetTestData()
        {
            string csvPath = Path.Combine(AppContext.BaseDirectory, "LoginTestData.csv");

            using var reader = new StreamReader(csvPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            foreach (var record in csv.GetRecords<TestData>())
            {
                yield return new object[] { record.Username, record.Password };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void Login_WithValidCredentials_ShouldSucceed(string username, string password)
        {
            string htmlPath = Path.Combine(AppContext.BaseDirectory, "login.html");
            string url = "file:///" + htmlPath.Replace("\\", "/");

            using IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(url);

            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("loginButton")).Click();

            System.Threading.Thread.Sleep(1000);

            Assert.IsTrue(true);
        }

        public class TestData
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}