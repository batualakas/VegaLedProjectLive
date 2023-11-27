using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VegaLedProject.Dtos.LoginDto;

[AllowAnonymous]
public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginUserDto loginUserDto, int id)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUserDto.UserName, loginUserDto.Password, false, false);

            if (result.Succeeded)
            {
                // Kullanıcının rollerini alıp, gerekirse yönlendirme yapabilirsiniz
                var user = await _signInManager.UserManager.FindByNameAsync(loginUserDto.UserName);
                var roles = await _signInManager.UserManager.GetRolesAsync(user);

                if (roles.Contains("admin"))
                {
                    // Kullanıcı admin rolüne sahipse Admin/Home'a yönlendir
                    return RedirectToAction("Home", "Admin");
                }
                else
                {
                    // Kullanıcı admin rolüne sahip değilse başka bir sayfaya yönlendir
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
             
                return View();
            }
        }

        return View();
    }
}