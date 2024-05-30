using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.ProductComments
{
    public class SearchProductCommentRequest : PaginatedRequest
    {
        public int productId { get; set; }
        public int customerId { get; set; }
        public string? comment { get; set; }
    }
}
