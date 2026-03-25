using System.ComponentModel.DataAnnotations;

namespace Presentation.WebApp.Areas.Authentication.Models;

public class SignUpForm
{
    [Required(ErrorMessage = "Email is required")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "username@example.com")]
    public string Email { get; set; } = null!;


    [Display(Name = "I Accept the user terms & conditions.")]
    [Range(typeof(bool), "true", "true", ErrorMessage = "Accepting the user terms & conditions is required")]
    public bool TermsAndConditions { get; set; }


    public string? ErrorMessage { get; set; }
}
