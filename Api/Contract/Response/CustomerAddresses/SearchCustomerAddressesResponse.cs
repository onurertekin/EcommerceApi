using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.CustomerAddresses
{
    public class SearchCustomerAddressesResponse
    {
        public class CustomerAddresses
        {
            public int id { get; set; }
            public string streetAddress { get; set; }
            public string streetAddress2 { get; set; }
            public string city { get; set; }
            public string zipPostalCode { get; set; }
            public string phoneNumber { get; set; }
            public bool isDefault { get; set; }
        }
        public SearchCustomerAddressesResponse()
        {
            customerAddresses = new List<CustomerAddresses>();
        }
        public List<CustomerAddresses> customerAddresses { get; set; }
        public int totalCount { get; set; }
    }
}
