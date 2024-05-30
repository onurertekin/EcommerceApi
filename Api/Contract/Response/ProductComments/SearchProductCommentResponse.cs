using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.ProductComments
{
    public class SearchProductCommentResponse
    {
        public class ProductComments
        {
            public int id { get; set; }
            public int productId { get; set; }
            public int customerId { get; set; }
            public string comment { get; set; }
        }

        public SearchProductCommentResponse()
        {
            productComments = new List<ProductComments> { };
        }
        public int totalCount { get; set; }
        public List<ProductComments> productComments { get; set; }
    }
}
