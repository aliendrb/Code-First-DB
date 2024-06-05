using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First.Models
{
    [Table("Shopping_Carts")]
    public class Shopping_Carts
    {
        [ForeignKey("Accounts")]
        [Column("FK_account")]
        public int AccountId { get; set; }
        public Accounts Accounts { get; set; }

        [ForeignKey("Products")]
        [Column("FK_product")]
        public int ProductId { get; set; }
        public Products Products { get; set; }

        [Column("amount")]
        public int Amount { get; set; }
    }
}
