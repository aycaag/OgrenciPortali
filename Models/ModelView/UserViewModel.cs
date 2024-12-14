using System.ComponentModel.DataAnnotations;

public class UserViewModel {
    public int ID { get; set; } 

    [Required(ErrorMessage = "Ad alanı boş girilemez")] 
    public string Name { get; set; } 

    
    [Required(ErrorMessage = "Soyad alanı boş girilemez")] 
    public string Surname { get; set; } 


    [Required(ErrorMessage = "Email alanı boş girilemez")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",ErrorMessage ="Email adres uygun değil")]
    public string Email { get; set; }   


    [Required(ErrorMessage = "Şifre alanı boş girilemez")] 
    [MinLength(8,ErrorMessage = "Girilen şifre en az 8 karakterli olmalıdır!")]
    public string Password { get; set; }  


    [Compare("Password" ,ErrorMessage="Şifre aynı olmalıdır.")]
    public string ConfirmPassword { get; set; }  

    public bool isConfirm {get;set;}  
}