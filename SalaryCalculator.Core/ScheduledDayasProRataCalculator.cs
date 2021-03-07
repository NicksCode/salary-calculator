using System;
using System.Linq;

namespace SalaryCalculator.Core
{
    public class ScheduledDaysProRataCalculator: IProRataCalculator
    {
        public decimal CalculateProRataRate(DateTime startingDate)
        {
            int daysInMonth = DateTime.DaysInMonth(startingDate.Year, startingDate.Month);

            int totalWorkingDays = Enumerable.Range(1, daysInMonth)
                                        .Where(day => isWeekDay(startingDate.Year, startingDate.Month, day))
                                        .Count();

            int daysWorked = Enumerable.Range(startingDate.Day, daysInMonth - startingDate.Day + 1)
                                .Where(d => isWeekDay(startingDate.Year, startingDate.Month, d))
                                .Count();

            return (Decimal)daysWorked / totalWorkingDays;
        }

        // Assumption is a 5 day normal week and we dont need to account for public holidays.
        // Should we wish to extend this we could inject an IWorkDaySchedule
        private bool isWeekDay(int year, int month, int day) {
            return
                new DateTime(year, month, day).DayOfWeek != DayOfWeek.Saturday &&
                new DateTime(year, month, day).DayOfWeek != DayOfWeek.Sunday;
        }

    }
}
