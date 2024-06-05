using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code_First.Models
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        [Column("PK_role")]
        public int RoleID { get; set; }

        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        IEnumerable<Accounts> Accounts { get; set; }
    }
}
