using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using System.Threading.Tasks;
using MVCProject.ViewModel;

namespace MVCProject.Controllers
{


    //CRUD Roles
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
        {
            private readonly RoleManager<IdentityRole> roleManager;

            public RoleController(RoleManager<IdentityRole> roleManager)
            {
                this.roleManager = roleManager;
            }

            [HttpGet]//Role/Craete "Get"
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]//Role/Craete "post"
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(RoleViewModel newRole)
            {
                if (ModelState.IsValid == true)
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = newRole.RoleName;
                    IdentityResult result = await roleManager.CreateAsync(role);//name already exist
                    if (result.Succeeded == true)
                    {
                        return View(new RoleViewModel());
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                    //save
                }
                return View(newRole);
            }
        }
    }

