using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.Orders
{
    public class SearchOrderResponse
    {
        public class Order
        {
            public int id { get; set; }
            public int customerId { get; set; }
            public int addressId { get; set; }
            public DateTime orderDate { get; set; }
            public int orderStatus { get; set; }
        }
        public SearchOrderResponse()
        {
            orders = new List<Order>();
        }
        public List<Order> orders { get; set; }
        public int totalCount { get; set; }
    }
}
