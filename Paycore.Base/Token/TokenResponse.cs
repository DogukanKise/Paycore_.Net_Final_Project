using System;
using System.ComponentModel.DataAnnotations;

namespace Paycore.Base.Token
{
    public class TokenResponse
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name ="Expire Time")]
        public DateTime ExpireTime { get; set; }

        [Display(Name = "Access Token")]
        public string AccessToken { get; set; }

    }
}
