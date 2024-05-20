﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities
{
    [Table("ProductComments")]
    public class ProductComment
    {
        public ProductComment()
        {
             Products = new HashSet<Product>();
             Customers = new HashSet<Customer>();
        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        public virtual ISet<Product> Products { get; set;}
        public virtual ISet<Customer> Customers { get; set;}
    }
}