using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.ProductImages
{
    public class SearchProductImageRequest : PaginatedRequest
    {
        public int id { get; set; }
        public int productId { get; set; }
    }
}
