using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.ViewModel;
using System.Threading.Tasks;

namespace MVCProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        [HttpGet]
       public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel userVm)
        {
            if (ModelState.IsValid==true)
            {
                //Save In Db
                ApplicationUser userModel=new ApplicationUser();
                userModel.address = userVm.Address;
                userModel.UserName = userVm.UserName;
                userModel.PasswordHash = userVm.Password;
               IdentityResult result=await  userManager.CreateAsync(userModel,userVm.Password);
                if (result.Succeeded)
                {
                    //Create cookie
                    await userManager.AddToRoleAsync(userModel, "User");
                    await signInManager.SignInAsync(userModel, false);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);

                    }
                }
            }
            return View(userVm);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userVm)
        {
            if (ModelState.IsValid == true)
            {

                ApplicationUser userModel = await userManager.FindByNameAsync(userVm.UserName);

                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, userVm.Password);
                    if (found == true)
                    {
                        await signInManager.SignInAsync(userModel,userVm.RemmeberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Name aND Password Not Correct!");


            } 
        
            return View(userVm);
        }

        public async Task<IActionResult> signOut()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        //---------------Add Admin
        [Authorize(Roles = "Admin")]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAdmin(RegisterViewModel userVm)
        {
            if (ModelState.IsValid == true)
            {
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = userVm.UserName;
                userModel.address = userVm.Address;
                userModel.PasswordHash = userVm.Password;//123 
                IdentityResult result = await userManager.CreateAsync(userModel, userVm.Password);//save db cookie
                if (result.Succeeded)
                {
                    //assign role to this account
                    await userManager.AddToRoleAsync(userModel, "Admin");

                    return RedirectToAction("Index", "ShowProduct");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);//password
                    }
                }
            }
            //not valid
            // return View("Register", userVm);
            return View(userVm);//view =Register
        }

    }
}
