using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }

        public virtual ISet<Customer> Customers { get; set; }
        public virtual ISet<Product> Products { get; set; }

    }
}
