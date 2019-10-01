using OpenQA.Selenium;

namespace SeleniumSample.Tests
{
   public class GoogleSearch : SeleniumTest
   {
      public GoogleSearch(IWebDriver driver) : base(driver)
      {
      }

      protected override TestResult ExecuteTest()
      {
         // Navigate to google
         Driver.Navigate().GoToUrl("https://www.google.com");

         // Find the search text box input by the name attribute
         var searchBox = Driver.FindElement(By.Name("q"));

         // Enter search text
         searchBox?.SendKeys("How to write selenium tests");

         // Submit the search form
         searchBox?.Submit();

         // Assume we succeeded
         return TestSucceeded();
      }
   }
}
