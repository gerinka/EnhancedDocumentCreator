using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Edc.WebClient.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Email адресът е задължителен")]
        [Display(Name = "Email адрес")]
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
        [Display(Name = "Код")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Запомни този браузър?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessage = "Email адресът е задължителен")]
        [Display(Name = "Email адрес")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email адресът е задължителен")]
        [Display(Name = "Email адрес")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Паролата е задължителна")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email адресът е задължителен")]
        [EmailAddress]
        [Display(Name = "Email адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Името е задължително")]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилията е задължителна")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Паролата е задължителна")]
        [StringLength(100, ErrorMessage = "{0}та трябва да бъде най-малко {2} символа дълга.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повтори парола")]
        [Compare("Password", ErrorMessage = "Паролата и повторената парола не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Email адресът е задължителен")]
        [EmailAddress]
        [Display(Name = "Email адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Паролата е задължителна")]
        [StringLength(100, ErrorMessage = "{0}та трябва да бъде най-малко {2} символа дълга.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повтори парола")]
        [Compare("Password", ErrorMessage = "Паролата и повторената парола не съвпадат.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email адресът е задължителен")]
        [EmailAddress]
        [Display(Name = "Email адрес")]
        public string Email { get; set; }
    }
}
