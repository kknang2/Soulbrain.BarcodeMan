using Soulbrain.BarcodeMan.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Soulbrain.BarcodeMan.Web.Models.Account
{
    public class Login
    {
        [Required]
        [Display(Name = "Login_UserID", ResourceType = typeof(Message))]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Login_Password", ResourceType = typeof(Message))]
        public string Password { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Login_RememberID", ResourceType = typeof(Message))]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}