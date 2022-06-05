using System;
using Xunit;
using ChallengeApp;

namespace Challenge.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void Test1()
        {
            //arange
            var emp = new Employee("Frank", new DateTime(9998, 11, 11));
            emp.AddGrade(100.0);
            emp.AddGrade(0.0);
            emp.AddGrade(0.0);
        
            //act 
            var result = emp.GetStatistics();

            //asert
            
            Assert.Equal(100.0, result.High);
            Assert.Equal(33.33, result.Average, 2);
            Assert.Equal(0.0, result.Low);
            Assert.Equal(200.0, result.Rise);
            
            
        }
    }
}
