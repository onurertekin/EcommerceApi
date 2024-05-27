using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.CustomerAddresses
{
    public class SearchCustomerAddressesRequest : PaginatedRequest
    {
        public int? id { get; set; }
        public string? streetAddress { get; set; }
        public string? streetAddress2 { get; set; }
        public string? city { get; set; }
        public string? zipPostalCode { get; set; }
        public string? phoneNumber { get; set; }
        public bool? isDefault { get; set; }

    }
}
