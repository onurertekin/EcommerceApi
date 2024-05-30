using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities
{
    [Table("ProductImages")]
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual ISet<Product> Products { get; set; } 
    }
}
