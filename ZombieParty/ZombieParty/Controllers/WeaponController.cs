using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;

namespace ZombieParty.Controllers
{
    public class WeaponController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Weapon weapon)
        {
            return View();
        }

    }
}
