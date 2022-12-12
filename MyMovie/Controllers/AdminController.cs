using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyMovie.Controllers
{
    public class AdminController : Controller
    {
        UserManager<IdentityUser> _userManager;

        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        public IActionResult Create()
        {
            return View(new IdentityUser());
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityUser user)
        {
            await _userManager.CreateAsync(user);
            return RedirectToAction("Index");
        }

		[HttpPost]
		public async Task<IActionResult> DeleteUser(string id)
		{
			var user = await _userManager.FindByIdAsync(id);

			if (user == null)
			{
				ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
				return View("NotFound");
			}
			else
			{
				var result = await _userManager.DeleteAsync(user);

				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}

				return View("Index");
			}
		}

		//[Authorize(Roles ="Admin")]
		//public IActionResult Index()
		//{
		//    return View();
		//}
	}
}
