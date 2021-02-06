using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdOut.Identity.Model.Database
{
    [Table("RolePermissions")]
    public class RolePermission
    {
        [ForeignKey(nameof(Role))]
        public string RoleId { get; set; }

        [ForeignKey(nameof(Permission))]
        public int PermissionId { get; set; }

        [Required]
        public virtual Role Role { get; set; }

        [Required]
        public virtual Permission Permission { get; set; }
    }
}
