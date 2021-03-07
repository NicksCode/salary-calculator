using System;
namespace SalaryCalculator.Core
{
    public interface IProRataCalculator
    {
        public Decimal CalculateProRataRate(DateTime startingDate);
    }
}
