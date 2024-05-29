using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.Products
{
    public class SearchProductResponse
    {
        public class Products
        {
            public int? id { get; set; }
            public string? name { get; set; }
            public string? description { get; set; }
            public decimal? price { get; set; }
            public int? quantity { get; set; }
            public DateTime createdOn { get; set; }
            public DateTime? updatedOn { get; set; }
        }
        public SearchProductResponse()
        {
            products = new List<Products>();
        }
        public int totalCount { get; set; }
        public List<Products> products { get; set; }
    }
}
