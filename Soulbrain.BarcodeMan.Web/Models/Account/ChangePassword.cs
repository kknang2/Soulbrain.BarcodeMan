using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Soulbrain.BarcodeMan.Web.Models.Account
{
    public class ChangePassword
    {
        [Display(Name = "PW_CurrentPassword")]
        public string CurrentPassword { get; set; }

        [Display(Name = "PW_NewPassword")]
        public string NewPassword { get; set; }
    }
}