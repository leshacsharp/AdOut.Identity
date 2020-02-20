using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdOut.Identity.Model.Database
{
    [Table("Permissions")]
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:15, MinimumLength=3)]
        public string Name { get; set; }

        public virtual ICollection<RolePermission> Roles { get; set; }
    }
}
