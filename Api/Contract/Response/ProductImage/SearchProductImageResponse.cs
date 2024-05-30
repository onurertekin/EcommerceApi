using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.ProductImage
{
    public class SearchProductImageResponse
    {
        public class ProductImages
        {
            public int id { get; set; }
            public int productId { get; set; }
        }
        public SearchProductImageResponse()
        {
            productImages = new List<ProductImages>();
        }
        public int totalCount { get; set; }
        public List<ProductImages> productImages { get; set; }
    }
}
