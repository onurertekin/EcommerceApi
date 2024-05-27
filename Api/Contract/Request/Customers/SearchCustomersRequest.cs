using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Customers
{
    public class SearchCustomersRequest : PaginatedRequest
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public string? gender { get; set; }
        public int status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
