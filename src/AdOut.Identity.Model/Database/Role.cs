using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AdOut.Identity.Model.Database
{
    public class Role : IdentityRole
    {
        public virtual ICollection<RolePermission> Permissions { get; set; }
    }
}
