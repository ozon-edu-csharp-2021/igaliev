using System;
using MerchandiseService.Domain.SeedWork;

namespace MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation
{
    public class ClothingSize : Enumeration
    {
        // https://lostechies.com/jimmybogard/2008/08/12/enumeration-classes/
        // https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types

        public static ClothingSize XS =  new(1, nameof(XS), "Extra small");
        public static ClothingSize S =   new(2, nameof(S), "Small");
        public static ClothingSize M =   new(3, nameof(M), "Medium");
        public static ClothingSize L =   new(4, nameof(L), "Large");
        public static ClothingSize XL =  new(5, nameof(XL), "Extra large");
        public static ClothingSize XXL = new(6, nameof(XXL), "Extra extra large");

        public string Description { get; }

        /// <inheritdoc />
        public ClothingSize(int id, string name, string description) : base(id, name)
            => Description = description;

        public ClothingSize Parse(string size)
            => size?.ToUpper() switch
            {
                "XS"  => XS,
                "S"   => S,
                "M"   => M,
                "L"   => L,
                "XL"  => XL,
                "XXL" => XXL,
                _ => throw new Exception("Unknown size")
            };
    }
}