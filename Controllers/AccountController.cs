using Microsoft.AspNetCore.Identity;using Microsoft.AspNetCore.Mvc;using Ordella_deliverable2.Models;
namespace Ordella_deliverable2.Controllers;
public class AccountController:Controller
{
 private readonly UserManager<IdentityUser> users;private readonly SignInManager<IdentityUser> signIn;
 public AccountController(UserManager<IdentityUser> u,SignInManager<IdentityUser>s){users=u;signIn=s;}
 [HttpGet] public IActionResult Register()=>User.Identity?.IsAuthenticated==true?RedirectToAction("Index","Dashboard"):View();
 [HttpPost,ValidateAntiForgeryToken] public async Task<IActionResult> Register(RegisterViewModel model){if(!ModelState.IsValid)return View(model);if(model.Role!="Seller"&&model.Role!="Customer"){ModelState.AddModelError("Role","Choose a valid account type.");return View(model);}var user=new IdentityUser{UserName=model.Email,Email=model.Email};var result=await users.CreateAsync(user,model.Password);if(result.Succeeded){await users.AddToRoleAsync(user,model.Role);await signIn.SignInAsync(user,false);return model.Role=="Seller"?RedirectToAction("Index","Dashboard"):RedirectToAction("Index","Home");}foreach(var e in result.Errors)ModelState.AddModelError("",e.Description);return View(model);}
 [HttpGet] public IActionResult Login(string? returnUrl=null){ViewBag.ReturnUrl=returnUrl;return View();}
 [HttpPost,ValidateAntiForgeryToken] public async Task<IActionResult> Login(LoginViewModel model,string? returnUrl=null){if(!ModelState.IsValid)return View(model);var result=await signIn.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false);if(result.Succeeded){if(!string.IsNullOrEmpty(returnUrl)&&Url.IsLocalUrl(returnUrl))return LocalRedirect(returnUrl);if(await users.IsInRoleAsync(await users.FindByEmailAsync(model.Email)!,"Seller"))return RedirectToAction("Index","Dashboard");return RedirectToAction("Index","Home");}ModelState.AddModelError("","Invalid login attempt.");return View(model);}
 [HttpPost,ValidateAntiForgeryToken] public async Task<IActionResult> Logout(){await signIn.SignOutAsync();return RedirectToAction("Index","Home");}
 public IActionResult AccessDenied()=>View();
}
