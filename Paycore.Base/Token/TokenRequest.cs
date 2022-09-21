using System.ComponentModel.DataAnnotations;

namespace Paycore.Base.Token
{
    public class TokenRequest
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
