using DesignPattern.Observer.DAL;
using DesignPattern.Observer.Models;
using DesignPattern.Observer.ObserverPattern;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesignPattern.Observer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ObserverObject _obServer;

        private readonly UserManager<AppUser> _userManager;

        public DefaultController(UserManager<AppUser> userManager, ObserverObject observerObject)
        {
            _userManager = userManager;   
            _obServer = observerObject;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            var appUser = new AppUser
            {
                NameSurname = model.NameSurname,
                UserName = model.UserName,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(appUser,model.Password);

            if (result.Succeeded)
            {
                _obServer.NotifyObserver(appUser);
                return View();
            }
            return View();
        }
    }
}
