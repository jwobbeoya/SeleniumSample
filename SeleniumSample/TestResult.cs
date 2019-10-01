using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumSample
{
   public class TestResult
   {
      public TestResult(string name, TestOutcome testOutcome, string message = null)
      {
         Name = name;
         TestOutcome = testOutcome;
         Message = message;
      }

      public string Name { get; set; }
      public TestOutcome TestOutcome { get; set; } 
      public string Message { get; set; }
   }

   public enum TestOutcome
   {
      Succeeded,
      Failed
   }
}
