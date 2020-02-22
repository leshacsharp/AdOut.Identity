using AdOut.Identity.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace AdOut.Identity.Model.Api
{
    //todo: add mobilePhone to this model and make regular expression for email, mobile phone
    public class RegistrationModel
    {
        [Required]
        [StringLength(maximumLength:20, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public Role Role { get; set; }

        public string Email { get; set; }
    }
}
