using DatabaseModel.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities
{
    [Table("Customers")]
    public class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<CustomerAddress>();
        }
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [StringLength(5)]
        public string Gender { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public CustomerStatus Status { get; set; }

        
        public virtual ISet<CustomerAddress> Addresses { get; set; }
        public virtual ISet<Order> Orders { get; set; }



    }
}
