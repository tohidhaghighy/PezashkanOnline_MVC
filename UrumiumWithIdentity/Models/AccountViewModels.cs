using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UrumiumMVC.DomainClasses.Entities.Common;

namespace IdentitySample.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "ایمیل نباید خالی باشد")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "کد")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "مرا به خاطر بسپار?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "ایمیل نباید خالی باشد")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "ایمیل نباید خالی باشد")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل خود را درست وارد کنید")]
        public string Email { get; set; }

        [Required(ErrorMessage = "موبایل نباید خالی باشد")]
        [Display(Name = "موبایل")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "پسورد نباید خالی باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "پسورد")]
        public string Password { get; set; }
       

        [Display(Name = "مرا به خاطر بسپار?")]
        public bool RememberMe { get; set; }

        
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "ایمیل نباید خالی باشد")]
        [EmailAddress(ErrorMessage ="ایمیل خود را درست وارد کنید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "پسورد نباید خالی باشد")]
        [StringLength(100, ErrorMessage = "حداقل 6 کارکتر باشد و ترکیبی از حروف بزرگ و کوچک و اعداد باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "پسورد")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار پسورد")]
        [Compare("Password", ErrorMessage = "پسورد ها با هم همخوانی ندارد")]
        public string ConfirmPassword { get; set; }

        public List<State> States { get; set; }
        public string Code { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "ایمیل نباید خالی باشد")]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "پسورد نباید خالی باشد")]
        [StringLength(100, ErrorMessage = "حداقل 6 کارکتر باشد و ترکیبی از حروف بزرگ و کوچک و اعداد باشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "پسورد")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار پسورد")]
        [Compare("Password", ErrorMessage = "پسورد ها با هم همخوانی ندارد")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "ایمیل نباید خالی باشد")]
        [EmailAddress(ErrorMessage = "ایمیل خود را درست وارد کنید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }
}