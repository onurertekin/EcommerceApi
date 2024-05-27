﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.OrderItem
{
    public class SearchOrderItemResponse
    {
        public class OrderItem
        {
            public int id { get; set; }
            public int orderId { get; set; }
            public int productId { get; set; }
            public int quantity { get; set; }
            public decimal unitPrice { get; set; }
        }
        public SearchOrderItemResponse()
        {
            orderItems= new List<OrderItem>();
        }
        public List<OrderItem> orderItems { get; set; }
        public int totalCount { get; set; }

    }
}
