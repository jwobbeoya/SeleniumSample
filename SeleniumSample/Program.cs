using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumSample
{
   internal class Program
   {
      private static readonly Type[] ConstructorTypes = new Type[] { typeof(IWebDriver) };

      private static void Main(string[] args)
      {

         try
         {
            // Run all the tests for Chrome
            RunTestsForChrome();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex);
         }
         finally
         {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
         }
      }

      private static void RunTestsForChrome()
      {
         // Note that there are drivers for other browsers too
         using (var chromeDriver = new ChromeDriver())
         {
            // Clear the console message
            Console.Clear();

            // Get an instance of each test that inherits from SeleniumTest for the chrome driver
            var tests = GetSeleniumTests(chromeDriver);

            // Run all the tests
            RunTestsForDriver(chromeDriver, tests);
         }
      }

      private static void RunTestsForDriver(IWebDriver driver, IEnumerable<SeleniumTest> tests)
      {
         try
         {
            // Run all tests for the driver
            foreach (var seleniumTest in tests)
            {
               seleniumTest
                  .Run()
                  .Print();
            }
         }
         finally
         {
            try
            {
               driver.Close();
            }
            catch 
            { 
               // Intentionally eat this. This can fail if the browser crashes or is manually closed by the user
            }
         }
      }

      private static IEnumerable<SeleniumTest> GetSeleniumTests(IWebDriver driver)
      {
         var seleniumTestType = typeof(SeleniumTest);
         var assembly = typeof(Program).Assembly;

         // Return an instance of each type in this assembly that inherits from SeleniumTest
         return assembly.GetTypes()
            .Where(type => type != seleniumTestType && seleniumTestType.IsAssignableFrom(type))
            .OrderBy(type => type.Name)
            .Select(type => CreateTestInstanceFromType(type, driver))
            .ToList();
      }

      private static SeleniumTest CreateTestInstanceFromType(Type type, IWebDriver driver)
      {
         // Call test constructor with driver argument
         return type.GetConstructor(ConstructorTypes)?.Invoke(new object[] { driver }) as SeleniumTest;
      }
   }
}