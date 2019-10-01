using System;

namespace SeleniumSample
{
   public static class TestResultExtension
   {
      public static void Print(this TestResult testResult)
      {
         var message = testResult.Message == null
            ? null
            : $"- {testResult.Message}";

         Console.WriteLine($"{testResult.Name}: {testResult.TestOutcome} {message}");
      }
   }
}