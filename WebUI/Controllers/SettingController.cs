using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.EntityLayer.Entities;
using WebUI.Dtos.IdentityDto;

namespace WebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var userEditDto = new UserEditDto();
            userEditDto.Mail = value.Email;
            userEditDto.UserName = value.UserName;
            userEditDto.Name = value.Name;
            userEditDto.Surname = value.Surname;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if (userEditDto.Password == userEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditDto.Name;
                user.Surname = userEditDto.Surname;
                user.Email = userEditDto.Mail;
                user.UserName = userEditDto.UserName;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
