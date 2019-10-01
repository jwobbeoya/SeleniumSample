using System;
using OpenQA.Selenium;

namespace SeleniumSample
{
   public abstract class SeleniumTest
   {
      protected SeleniumTest(IWebDriver driver)
      {
         Driver = driver;
      }

      protected virtual string TestName => this.GetType().Name;

      protected IWebDriver Driver { get; }

      public TestResult Run()
      {
         try
         {
            return ExecuteTest();
         }
         catch (Exception ex)
         {
            return  new TestResult(TestName, TestOutcome.Failed, ex.Message);
         }
      }

      public TestResult TestSucceeded(string message = null)
      {
         return new TestResult(TestName, TestOutcome.Succeeded, message);
      }

      public TestResult TestFailed(string message)
      {
         return new TestResult(TestName, TestOutcome.Failed, message);
      }

      protected abstract TestResult ExecuteTest();

   }
}