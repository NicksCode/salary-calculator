using System;
using System.Collections.Generic;
using NUnit.Framework;
using SalaryCalculator.Core;
namespace SalaryCalculator.Tests
{
    public class ProRataQueryTest
    {

        [Test]
        public void ShouldNotThrowExceptionWhenCalculateHighestDiscrepency()
        {

            var query = new ProRataQueries(
                                2020,
                                new CalendarDaysProRataCalculator(),
                                new ScheduledDaysProRataCalculator()
                               );

            Assert.DoesNotThrow(() => query.CalculateHighestDiscrepency(142042m));
        }
    }
}