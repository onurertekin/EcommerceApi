using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Orders
{
    public class SearchOrderRequest : PaginatedRequest
    {
        public int? customerId { get; set; }
        public int? addressId { get; set; }
        public DateTime? orderDate { get; set; }
        public int? orderStatus { get; set; }
    }
}
