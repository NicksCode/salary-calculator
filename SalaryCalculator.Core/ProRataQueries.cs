using System;
using System.Linq;

namespace SalaryCalculator.Core
{
    public class ProRataQueries
    {
        private IProRataCalculator _calendarDaysCalculator;
        private IProRataCalculator _scheduledDaysCalculator;
        private int _year;
        public ProRataQueries(int year, IProRataCalculator calendarDaysCalulator, IProRataCalculator scheduledDaysProRataCalculator)
        {
            _calendarDaysCalculator = calendarDaysCalulator;
            _scheduledDaysCalculator = scheduledDaysProRataCalculator;
            _year = year;
        }


        public Result[] CalculateHighestDiscrepency(decimal annualSalary) {

            decimal monthlySalary = annualSalary / 12;

            var results = Enumerable.Range(1, 12)
                .SelectMany(month => CalculateDiscrepencyPerMonth(_year, month, monthlySalary));

            return results.GroupBy(r => r.Discrepency)
                .OrderByDescending(g => g.Key)
                .FirstOrDefault()
                .ToArray();
        }

        private Result[] CalculateDiscrepencyPerMonth(int year, int month, decimal monthlySalary) {

            int daysInTheMonth = DateTime.DaysInMonth(year, month);

            var fullList =  Enumerable.Range(1, daysInTheMonth)
                .Select(day => CalculateDiscrepencyPerDay(month, day, monthlySalary))
                .ToArray();


            var result = fullList.OrderByDescending(r => r.Discrepency);

            return fullList;
        }

        private Result CalculateDiscrepencyPerDay(int month, int day, decimal monthlySalary)
        {
            var startingDate = new DateTime(_year, month, day);

            var rateAsPerCalendarDays = _calendarDaysCalculator.CalculateProRataRate(startingDate);
            var rateAsPerScheduleDays = _scheduledDaysCalculator.CalculateProRataRate(startingDate);

            var salaryCalendarDays = Math.Round(monthlySalary * rateAsPerCalendarDays, 2);
            var salaryScheduledDays = Math.Round(monthlySalary * rateAsPerScheduleDays);
            var discrepency = Math.Abs(salaryCalendarDays - salaryScheduledDays);

            return new Result()
            {
                StartingDate = startingDate,
                Discrepency = discrepency,
                SalaryAsPerCalendarDays = salaryCalendarDays,
                SalaryAsPerScheduledDays = salaryScheduledDays,
            };
        }
    }
}
