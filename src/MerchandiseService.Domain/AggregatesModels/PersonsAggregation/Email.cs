using MerchandiseService.Domain.SeedWork;
using System.Collections.Generic;

namespace MerchandiseService.Domain.AggregatesModels.PersonsAggregation
{
    public class Email : ValueObject
    {
        public Email(string value)
            => Value = value;

        public string Value { get; }

        public static Email Parse(string number)
        {
            // Do some parsing logic
            return new(number);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}