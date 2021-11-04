using System.Collections.Generic;
using MerchandiseService.Domain.SeedWork;

namespace MerchandiseService.Domain.AggregatesModels.PersonsAggregation
{
    public class PersonName:ValueObject
    {
        public string FirstName { get;}
        public string LastName { get;}
        public string MiddleName { get; }

        public PersonName(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            yield return MiddleName;
        }
        
    }
}