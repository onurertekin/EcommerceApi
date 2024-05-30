using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.ProductComments
{
    public class GetSingleProductCommentResponse
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int customerId { get; set; }
        public string comment { get; set; }
    }
}
