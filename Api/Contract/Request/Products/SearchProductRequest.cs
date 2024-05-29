using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Products
{
    public class SearchProductRequest : PaginatedRequest
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public decimal? price { get; set; }
        public int? quantity { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime? updatedOn { get; set; }
    }
}
