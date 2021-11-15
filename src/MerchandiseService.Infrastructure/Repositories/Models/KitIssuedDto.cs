using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Repositories.Models
{
        public class KitIssuedDto
        {
            public bool IsIssued { get; set; }
            public DateTime? dateTime { get; set; }
            public int? merchKitId { get; set; }
        }
}
