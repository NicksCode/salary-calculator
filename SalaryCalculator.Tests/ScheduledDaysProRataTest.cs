using System;
using NUnit.Framework;
using SalaryCalculator.Core;

namespace SalaryCalculator.Tests
{
    public class CalendarDaysProRataTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanCalculateCalendarDaysWhenMonthHas30Days()
        {
            // calendar days looks at how many days of the month they were employed.
            // When an employee starts mid - month, and the company pays monthly, their first month’s pay must be pro-rated based on how much of the month they worked.
            // There are 2 methods to calculate this, calendar days and scheduled days.
            // Calendar days looks at how many days of the month they were employed.Eg.If they started on the 21st in a month with 30 days, then they were employed 10 out of the 30 days, therefore their monthly salary would be 10 / 30 of their full monthly salary.

            var startingDate = new DateTime(2020,4, 21);
            decimal expected = 10.0m / 30.0m;

            var calc = new CalendarDaysProRataCalculator();
            var actual = calc.CalculateProRataRate(startingDate);


            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalendarDaysShouldCalculateProRataCorrectlyWhenStartingOnTheFirstDay() {
            var startingDate = new DateTime(2020, 4, 1);
            decimal expected = 1;

            var calc = new CalendarDaysProRataCalculator();
            var actual = calc.CalculateProRataRate(startingDate);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void CalendarDaysShouldCalculateProRataCorrectlyWhenStartingOnTheLastDay()
        {
            var startingDate = new DateTime(2020, 4, 30);
            decimal expected = 1/30;

            var calc = new CalendarDaysProRataCalculator();
            var actual = calc.CalculateProRataRate(startingDate);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void CalendarDaysShouldCalculateProRataCorrectlyWhenStartingLastDayFebruaryLeapYear()
        {
            var startingDate = new DateTime(2020, 2, 29);
            decimal expected = 1m/29m;

            var calc = new CalendarDaysProRataCalculator();
            var actual = calc.CalculateProRataRate(startingDate);

            Assert.AreEqual(expected, actual);
        }




    }
}