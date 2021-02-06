using System.ComponentModel.DataAnnotations;

namespace AdOut.Identity.Model.Api
{
    public class LogInModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }

        public bool Remember { get; set; }

        public string ReturnUrl { get; set; }
    }
}
