using System.Collections.Generic;
using MerchandiseService.Domain.SeedWork;

namespace MerchandiseService.Domain.MerchOrderAggregation
{
    public class Date : ValueObject
    {
        public int Day { get; }

        public int Month { get; }

        public int Year { get; }

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Day;
            yield return Month;
            yield return Year;
        }
    }
}