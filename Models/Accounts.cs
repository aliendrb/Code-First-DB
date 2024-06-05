using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First.Models
{
    [Table("Accounts")]
    public class Accounts
    {
        [Key]
        [Column("PK_account")]
        public int AccountId { get; set; }

        [ForeignKey("Roles")]
        [Column("FK_role")]
        public int RoleId { get; set; }

        public Roles Roles { get; set; }

        [Column("first_name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column("email")]
        [MaxLength(80)]
        public string Email { get; set; }

        [Column("phone")]
        [MaxLength(9)]
        public string? Phone { get; set; }

        public IEnumerable<Shopping_Carts> Shopping_Carts { get; set; }
    }
}
