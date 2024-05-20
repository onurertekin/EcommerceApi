using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities
{
    [Table("CustomerAddresses")]
    public class CustomerAddress
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        [StringLength(500)]
        public string StreetAddress { get; set; }

        [StringLength(500)]
        public string StreetAddress2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(20)]
        public string ZipPostalCode { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public bool IsDefault { get; set; }

        public virtual ISet<Customer> Customers { get; set; }
    }
}
