using System;
using System.Collections.Generic;
using NUnit.Framework;
using SalaryCalculator.Core;

namespace SalaryCalculator.Tests
{
    public class CalendarDaysProRataTest
    {
        public static IEnumerable<TestCaseData> TestCaseDataSource
        {
            get
            {
                yield return new TestCaseData( new DateTime(2020,4,21), 10m/30m);
                yield return new TestCaseData(new DateTime(2020, 4, 1), 1m);
                yield return new TestCaseData(new DateTime(2020, 2, 29), 1m / 29m);
                yield return new TestCaseData(new DateTime(2020, 2, 28), 2m / 29m);
            }
        }


        [Test]
        [TestCaseSource(typeof(CalendarDaysProRataTest), "TestCaseDataSource")]
        public void ShouldCalculateCorrectProRataRate(DateTime startingDate, decimal expectedProRataRatio)
        {
            var calc = new CalendarDaysProRataCalculator();
            var actualProRataRatio = calc.CalculateProRataRate(startingDate);
            Assert.AreEqual(expectedProRataRatio, actualProRataRatio);
        }
    }
}