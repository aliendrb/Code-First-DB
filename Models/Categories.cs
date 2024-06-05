using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        [Column("PK_Category")]
        public int CategoryID { get; set; }

        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        public IEnumerable<Products_Categories> Products_Categories { get; set; } 
    }
}
