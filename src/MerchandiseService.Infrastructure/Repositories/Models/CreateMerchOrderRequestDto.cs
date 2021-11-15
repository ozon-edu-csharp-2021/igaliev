using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Repositories.Models
{
  public   class CreateMerchOrderRequestDto
    {
        public long EmployeeId { get; set; }
        public long ManagerId { get; set; }
        public int MerchKitId { get; set; }
        public int? ClothingSize { get; set; }

    }
}
