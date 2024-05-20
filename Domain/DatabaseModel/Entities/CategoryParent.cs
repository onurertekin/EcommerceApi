using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities
{
    [Table("CategoryParents")]
    public class CategoryParent
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}
