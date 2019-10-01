using System.Linq;
using OpenQA.Selenium;

namespace SeleniumSample.Tests
{
   public class BingSearchSuccess : SeleniumTest
   {
      public BingSearchSuccess(IWebDriver driver) : base(driver)
      {
      }

      protected override TestResult ExecuteTest()
      {
         // Navigate to bing
         Driver.Navigate().GoToUrl("https://www.bing.com");

         // Find the search text box input by the id attribute
         var searchBox = Driver.FindElement(By.Id("sb_form_q"));

         // Enter search text
         searchBox?.SendKeys("C# Tutorial");

         // Submit the search form
         searchBox?.Submit();

         // Find the search result list items by class name
         var listItems = Driver.FindElements(By.ClassName("b_algo"));

         // Return test result based on matching text in results
         return listItems.Any(li => li.FindElement(By.TagName("a")).Text.Contains("C#")) 
            ? TestSucceeded() 
            : TestFailed("Search results missing");
      }
   }
}
