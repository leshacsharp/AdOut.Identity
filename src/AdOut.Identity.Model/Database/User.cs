using System;
using Microsoft.AspNetCore.Identity;

namespace AdOut.Identity.Model.Database
{
    public class User : IdentityUser
    {
        public DateTime DateRegistration { get; set; }
    }
}
