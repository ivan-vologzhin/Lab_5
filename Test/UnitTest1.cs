using Lab_5;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test
{

    [TestFixture]
    public class SearchFilterTests
    {
        private IWebDriver driver;
        private SearchFilterPage searchFilterPage;

        [SetUp]
        public void Setup()
        {
            // Инициализация WebDriver и открытие страницы поиска и фильтрации
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/SearchFilter/");
            searchFilterPage = new SearchFilterPage(driver);
        }

        [TearDown]
        public void Teardown()
        {
            // Завершение работы WebDriver
            driver.Quit();
        }

        [Test]
        public void TestSearchByPayee()
        {
            searchFilterPage.SelectSearchByPayee("InternetBill");
           var results = searchFilterPage.GetSearchResults();
            // Проверка результатов поиска по полученным данным
            Assert.That(results.Count, Is.EqualTo(2)); // Проверяем, что получено 4 результатов поиска
            CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "EXPENDITURE", "InternetBill", "500" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "InternetBill", "1200" });           // Проверяем, что среди результатов есть "InternetBill"

        }

        [Test]
        public void TestSearchByPayee2()
        {
            searchFilterPage.SelectSearchByPayee("");
            IList<List<string>> results = searchFilterPage.GetSearchResults();

            // Проверка результатов поиска по полученным данным
            Assert.That(results.Count, Is.EqualTo(5)); // Проверяем, что получено 4 результатов поиска
            CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "EXPENDITURE", "InternetBill", "500" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "HouseRent", "1000"});     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "InternetBill", "1200" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "INCOME", "Salary", "5000" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "PowerBill", "200" });     // Проверяем, что среди результатов есть "HouseRent"
        }

        //[Test]
        //public void TestSearchByPayeeEx()
        //{
        //    searchFilterPage.SelectSearchByPayee("EXPENDITURE");
        //    IList<List<string>> results = searchFilterPage.GetSearchResults();

        //    // Проверка результатов поиска по полученным данным
        //    Assert.That(results.Count, Is.EqualTo(4)); // Проверяем, что получено 4 результатов поиска
        //    CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "EXPENDITURE", "InternetBill", "500" });     // Проверяем, что среди результатов есть "HouseRent"
        //    CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "HouseRent", "1000" });     // Проверяем, что среди результатов есть "HouseRent"
        //    CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "InternetBill", "1200" });     // Проверяем, что среди результатов есть "HouseRent"
        //    CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "PowerBill", "200" });     // Проверяем, что среди результатов есть "HouseRent"
        //}


        [Test]
        public void TestSearchByPayeeBe()
        {
            searchFilterPage.SelectSearchByPayee("qwert");
            IList<List<string>> results = searchFilterPage.GetSearchResults();

            // Проверка результатов поиска по полученным данным
            Assert.That(results.Count, Is.EqualTo(0)); // Проверяем, что получено 4 результатов поиска
              
        }

        [Test]
        public void TestSearchByAccount()
        {
            searchFilterPage.SelectSearchByAccount();
            searchFilterPage.SelectAccount("All Accounts");
            IList<List<string>> results = searchFilterPage.GetSearchResults();
            Assert.That(results.Count, Is.EqualTo(5)); // Проверяем, что получено 2 результатов поиска
            CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "EXPENDITURE", "InternetBill", "500" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "HouseRent", "1000" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "InternetBill", "1200" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "INCOME", "Salary", "5000" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "PowerBill", "200" });
        }

        [Test]
        public void TestSearchByAccount2()
        {
            searchFilterPage.SelectSearchByAccount();
            searchFilterPage.SelectAccount("Cash");
            IList<List<string>> results = searchFilterPage.GetSearchResults();
            Assert.That(results.Count, Is.EqualTo(3)); // Проверяем, что получено 2 результатов поиска  
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "HouseRent", "1000" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "InternetBill", "1200" });     // Проверяем, что среди результатов есть "HouseRent"   
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "PowerBill", "200" });
        }

        [Test]
        public void TestSearchByAccount3()
        {
            searchFilterPage.SelectSearchByAccount();
            searchFilterPage.SelectAccount("Bank Savings");
            IList<List<string>> results = searchFilterPage.GetSearchResults();
            Assert.That(results.Count, Is.EqualTo(2)); // Проверяем, что получено 2 результатов поиска  
            CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "EXPENDITURE", "InternetBill", "500" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "INCOME", "Salary", "5000" });     // Проверяем, что среди результатов есть "HouseRent"
        }

        [Test]
        public void TestSearchByType()
        {
            searchFilterPage.SelectSearchByType();
            searchFilterPage.SelectType("EXPENDITURE");
            var results = searchFilterPage.GetSearchResults();
            Assert.That(results.Count, Is.EqualTo(4)); // Проверяем, что получено 2 результатов поиска
            CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "EXPENDITURE", "InternetBill", "500" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "HouseRent", "1000" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "InternetBill", "1200" });
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "PowerBill", "200" });
        }

        [Test]
        public void TestSearchByType2()
        {
            searchFilterPage.SelectSearchByType();
            searchFilterPage.SelectType("All Types");
            var results = searchFilterPage.GetSearchResults();
            Assert.That(results.Count, Is.EqualTo(5)); // Проверяем, что получено 2 результатов поиска
            CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "EXPENDITURE", "InternetBill", "500" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "HouseRent", "1000" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "InternetBill", "1200" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "INCOME", "Salary", "5000" });     // Проверяем, что среди результатов есть "HouseRent"
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "PowerBill", "200" });
        }

        [Test]
        public void TestSearchByType3()
        {
            searchFilterPage.SelectSearchByType();
            searchFilterPage.SelectType("INCOME");
            var results = searchFilterPage.GetSearchResults();
            Assert.That(results.Count, Is.EqualTo(1)); // Проверяем, что получено 2 результатов поиска
            CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "INCOME", "Salary", "5000" });
        }

        [Test]
        public void TestSearchByPayeeCombo()
        {
            searchFilterPage.SelectSearchByAccount();
            searchFilterPage.SelectAccount("Bank Savings");
            searchFilterPage.SelectSearchByType();
            searchFilterPage.SelectType("EXPENDITURE");
            var results = searchFilterPage.GetSearchResults();
            Assert.That(results.Count, Is.EqualTo(1)); // Проверяем, что получено 4 результатов поиска
            CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "EXPENDITURE", "InternetBill", "500" });     // Проверяем, что среди результатов есть "HouseRent"
           
        }

        [Test]
        public void TestSearchByPayeeCombo2()
        {
            searchFilterPage.SelectSearchByPayee("HouseRent");
            searchFilterPage.SelectSearchByType();
            searchFilterPage.SelectType("EXPENDITURE");
            var results = searchFilterPage.GetSearchResults();
            Assert.That(results.Count, Is.EqualTo(1)); // Проверяем, что получено 4 результатов поиска
                
            CollectionAssert.Contains(results, new List<string>() { "Cash", "EXPENDITURE", "HouseRent", "1000" });     // Проверяем, что среди результатов есть "HouseRent"
                // Проверяем, что среди результатов есть "HouseRent"

        }

        [Test]
        public void TestSearchByPayeeCombo3()
        {
            searchFilterPage.SelectSearchByPayee("");
            searchFilterPage.SelectSearchByAccount();
            searchFilterPage.SelectAccount("All Accounts");
            searchFilterPage.SelectSearchByType();
            searchFilterPage.SelectType("INCOME");
            var results = searchFilterPage.GetSearchResults();
            Assert.That(results.Count, Is.EqualTo(1)); // Проверяем, что получено 4 результатов поиска

            CollectionAssert.Contains(results, new List<string>() { "Bank Savings", "INCOME", "Salary", "5000" });      // Проверяем, что среди результатов есть "HouseRent"
                                                                                                                        // Проверяем, что среди результатов есть "HouseRent"

        }


        // Другие тестS

    }
}