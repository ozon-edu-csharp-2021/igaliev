using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchService.Models
{
    public class GetMerchItemRequestModel
    {
        public GetMerchItemRequestModel(long id, long employeeId, string status)
        {
            Id = id;
            EmployeeId = employeeId;
            Status = status;
        }

        long Id { get;  }
        long EmployeeId { get;  }
        string Status { get;  }
    }
}
