using System;

namespace MerchadiseSevice.Application.Orders.Queries.CheckIsMerchIssuedQuery
{
    public class KitIssuedDto
    {
        public bool IsIssued { get; set; }
        public DateTime? dateTime { get; set; }
        public int? merchKitId { get; set; }
    }
}