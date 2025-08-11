using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.EntityLayer.Entities;
using WebUI.Dtos.IdentityDto;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _sıgnInManager;

        public LoginController(SignInManager<AppUser> sıgnInManager)
        {
            _sıgnInManager = sıgnInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var result = await _sıgnInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Statistic");
            }
            return View();
        }
    }
}
