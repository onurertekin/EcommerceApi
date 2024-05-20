using DatabaseModel.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModel.Entities
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }
        public int CategoryParentId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public CategoryStatus Status { get; set; }

        public virtual ISet<Product> Products { get; set; }  
        public virtual ISet<CategoryParent> CategoryParent { get; set; }


    }
}
