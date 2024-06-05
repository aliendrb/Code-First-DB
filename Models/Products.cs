using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        [Column("PK_product")]
        public int ProductID { get; set; }

        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("weight")]
        public decimal Weight { get; set; }

        [Column("width")]
        public decimal Width { get; set; }

        [Column("height")]
        public decimal Height { get; set; }

        [Column("depth")]
        public decimal Depth { get; set; }

        public IEnumerable<Shopping_Carts> Shopping_Carts { get; set; }

        public IEnumerable<Products_Categories> Products_Categories { get; set;}
    }
}
