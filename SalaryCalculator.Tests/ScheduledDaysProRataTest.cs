using System;
using System.Collections.Generic;
using NUnit.Framework;
using SalaryCalculator.Core;

namespace SalaryCalculator.Tests
{
    public class ScheduleDaysProRataTest
    {
        public static IEnumerable<TestCaseData> TestCaseDataSource
        {
            get
            {
                yield return new TestCaseData(new DateTime(2020, 4, 21), 8m / 22m);
                yield return new TestCaseData(new DateTime(2020, 4, 1), 1m);
                yield return new TestCaseData(new DateTime(2020, 2, 29), 0m / 20m);
                yield return new TestCaseData(new DateTime(2020, 2, 28), 1m / 20m);
            }
        }

        [Test]
        [TestCaseSource(typeof(ScheduleDaysProRataTest), "TestCaseDataSource")]
        public void ShouldCalculateCorrectProRataRate(DateTime startingDate, decimal expectedProRataRatio)
        {
            var calc = new ScheduledDaysProRataCalculator();
            var actualProRataRatio = calc.CalculateProRataRate(startingDate);
            Assert.AreEqual(expectedProRataRatio, actualProRataRatio);
        }
    }
}