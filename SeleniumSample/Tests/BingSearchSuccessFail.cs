using System.Linq;
using OpenQA.Selenium;

namespace SeleniumSample.Tests
{
   public class BingSearchFail : SeleniumTest
   {
      public BingSearchFail(IWebDriver driver) : base(driver)
      {
      }

      protected override TestResult ExecuteTest()
      {
         // Navigate to bing
         Driver.Navigate().GoToUrl("https://www.bing.com");

         // Find the search text box input by the class attribute
         var searchBox = Driver.FindElement(By.ClassName("b_searchbox"));

         // Enter search text
         searchBox?.SendKeys("C# Tutorial");

         // Submit the search form
         searchBox?.Submit();

         // Find the search result list items by class name
         var listItems = Driver.FindElements(By.ClassName("b_algo"));

         // Intentional test failure
         return listItems.Any(li => li.FindElement(By.TagName("a")).Text.Contains("You won't find this string in the results'")) 
            ? TestSucceeded() 
            : TestFailed("Search results missing");
      }
   }
}
