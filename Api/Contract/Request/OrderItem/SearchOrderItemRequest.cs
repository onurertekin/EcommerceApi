using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.OrderItem
{
    public class SearchOrderItemRequest : PaginatedRequest
    {
        public int orderId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
    }
}
