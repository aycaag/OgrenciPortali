using System.ComponentModel.DataAnnotations;

using FluentValidation;

public class UserViewModel {
    public int ID { get; set; } 

    // [Required(ErrorMessage = "Ad alanı boş girilemez")] 
    public string Name { get; set; } 

    
    // [Required(ErrorMessage = "Soyad alanı boş girilemez")] 
    public string Surname { get; set; } 


    // [Required(ErrorMessage = "Email alanı boş girilemez")]
    // [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",ErrorMessage ="Email adres uygun değil")]
    public string Email { get; set; }   


    // [Required(ErrorMessage = "Şifre alanı boş girilemez")] 
    // [MinLength(8,ErrorMessage = "Girilen şifre en az 8 karakterli olmalıdır!")]
    public string Password { get; set; }  


    // [Compare("Password" ,ErrorMessage="Şifre aynı olmalıdır.")]
    public string ConfirmPassword { get; set; }  

    public bool isConfirm {get;set;}  
}




public class UserModelValidator : AbstractValidator<UserViewModel>
{
    public UserModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ad alanı boş olamaz.")
            .MinimumLength(3).WithMessage("Name en az 3 karakter olmalıdır.");
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Soyad alanı boş olamaz.");

        RuleFor(x=> x.Email)
            .NotEmpty().WithMessage("Email alanı boş olamaz")
            .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
            .EmailAddress()
            .WithMessage("Geçerli bir mail adresi giriniz");

        RuleFor(x=>x.Password)
            .NotEmpty().WithMessage("Şifre alanı boş olamaz")
            .MinimumLength(8).WithMessage("Şifre en az 8 karakterli olmalıdır");

        RuleFor(x=>x.ConfirmPassword)
            .Equal(x=>x.Password).WithMessage("Şifre alanı aynı olmalıdır. ");

    }
}