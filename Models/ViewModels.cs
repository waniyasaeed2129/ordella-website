using System.ComponentModel.DataAnnotations;
namespace Ordella_deliverable2.Models;
public class RegisterViewModel
{
 [Required, StringLength(80)] public string FullName {get;set;} = "";
 [Required, EmailAddress] public string Email {get;set;} = "";
 [Required, DataType(DataType.Password), MinLength(6)] public string Password {get;set;} = "";
 [Required, DataType(DataType.Password), Compare(nameof(Password))] public string ConfirmPassword {get;set;} = "";
 [Required] public string Role {get;set;} = "Customer";
}
public class LoginViewModel
{
 [Required,EmailAddress] public string Email {get;set;} = "";
 [Required,DataType(DataType.Password)] public string Password {get;set;} = "";
 public bool RememberMe {get;set;}
}
public class CheckoutViewModel
{
 [Required] public string CustomerName {get;set;} = ""; [Required,EmailAddress] public string CustomerEmail {get;set;} = "";
 [Required] public string CustomerPhone {get;set;} = ""; public string? Notes {get;set;}
}
