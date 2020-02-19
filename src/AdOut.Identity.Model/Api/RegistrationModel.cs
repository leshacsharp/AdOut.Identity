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

        [Required]
        [Compare(nameof(Password))]
        public string ComparedPassword { get; set; }

        //todo: probable need to change than on Enum
        public string Role { get; set; }

        public string Email { get; set; }
    }
}
