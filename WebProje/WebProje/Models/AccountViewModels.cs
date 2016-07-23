using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }
    
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string MemberPassword { get; set; }
        public Nullable<System.DateTime> MemberDOB { get; set; }
        public int MemberGroupID { get; set; }
        public int MemberReputationID { get; set; }
        public Nullable<System.DateTime> MemberRegisterDate { get; set; }
        public byte[] MemberPhoto { get; set; }
    }
}
