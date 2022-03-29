using Litera.Business.Services.Interfaces;
using Litera.Business.ViewModels.UserView;
using Microsoft.AspNetCore.Mvc;

namespace Litera.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ActionResult> Index()
        {
            var users = await _userService.GetAllAsync();
            return View(users);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _userService.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _userService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(UserViewModel user)
        {
            try
            {
                await _userService.Delete(user.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
