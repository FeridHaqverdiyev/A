using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.BAdmin.ViewModels;
using MVC.Models;

namespace MVC.Areas.BAdmin.Controllers
{
    [Area("BAdmin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser>  _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]  
        public async Task<IActionResult>Register(RegisterVM UserVM)
        { 
            if(!ModelState.IsValid)
            {
                return View(UserVM);
            }
            AppUser user = new AppUser
            {
                Name = UserVM.Name,
                Email = UserVM.Email,
                SurName = UserVM.SurName,
                UserName= UserVM.UserName,

            };
            IdentityResult result= await _userManager.CreateAsync(user,UserVM.Password);
            if(result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                return View();
            }
            await _signInManager.SignInAsync(user, isPersistent: false);
            return View(user);
            
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM LoginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(LoginVM);
            }
            AppUser user = await _userManager.FindByEmailAsync(LoginVM.UsernameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(LoginVM.UsernameOrEmail);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "eroor");
                }
            }
            var result = await _signInManager.PasswordSignInAsync(user, LoginVM.Password, LoginVM.isRemembered, true);
            if(result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "errror");
                return View(LoginVM);
            }
            if(result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "errror");
                return View(LoginVM);
            }
            return RedirectToAction("Index","Home");

          

        }

    }
}
