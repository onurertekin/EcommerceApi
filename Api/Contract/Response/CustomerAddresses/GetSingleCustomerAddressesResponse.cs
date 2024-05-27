using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.CustomerAddresses
{
    public class GetSingleCustomerAddressesResponse
    {
        public int id { get; set; }
        public string streetAddress { get; set; }
        public string streetAddress2 { get; set; }
        public string city { get; set; }
        public string zipPostalCode { get; set; }
        public string phoneNumber { get; set; }
        public bool isDefault { get; set; }
    }
}
