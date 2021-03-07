using System;
namespace SalaryCalculator.Core
{
    public class CalendarDaysProRataCalculator: IProRataCalculator
    {
        public CalendarDaysProRataCalculator()
        {
        }

        public decimal CalculateProRataRate(DateTime startingDate)
        {
            int daysInMonth = DateTime.DaysInMonth(startingDate.Year, startingDate.Month);
            int calendarDaysWorked = new DateTime(startingDate.Year, startingDate.Month, daysInMonth)
                .Subtract(startingDate)
                .Days + 1;

            return (decimal)calendarDaysWorked/daysInMonth;
        }
    }
}
