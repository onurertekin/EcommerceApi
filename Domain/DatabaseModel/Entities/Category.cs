using DatabaseModel.Enumerations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModel.Entities
{
    [Table("Categories")]
    public class Category
    {
        public Category()
        {

        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public CategoryStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }


    }
}
