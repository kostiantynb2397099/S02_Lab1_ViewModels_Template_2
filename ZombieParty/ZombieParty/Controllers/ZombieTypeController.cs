using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;
using ZombieParty.ViewModels;

namespace ZombieParty.Controllers
{
    public class ZombieTypeController : Controller
    {
        private BaseDonnees _baseDonnees { get; set; }

        public ZombieTypeController(BaseDonnees baseDonnes)
        {
            _baseDonnees = baseDonnes;
        }

        public IActionResult Index()
        {
            List<ZombieType> zombieTypeList = _baseDonnees.ZombieTypes.ToList();
            return View(zombieTypeList);
        }

        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Models.ZombieType zombieType)
        {
            if (ModelState.IsValid)
            {
                // Ajouter à la BD
                _baseDonnees.ZombieTypes.Add(zombieType);
                TempData["Success"] = $"{zombieType.TypeName} zombie type added";
                return this.RedirectToAction("Index");
            }

            return this.View(zombieType);
        }

        public IActionResult Details(int id)
        {
            ZombieTypeVM zombieTypeVM = new()
            {
                ZombieType = new(),
                ZombiesList = _baseDonnees.Zombies.Where(z => z.ZombieTypeId == id).ToList(),
                ZombiesCount = _baseDonnees.Zombies.Where(z => z.ZombieTypeId == id).Count(),
                PointsAverage = _baseDonnees.Zombies.Where(z => z.ZombieTypeId == id).Average(p => p.Point)

            };

            zombieTypeVM.ZombieType = _baseDonnees.ZombieTypes.FirstOrDefault(zt => zt.Id == id);
            return View(zombieTypeVM);
        }
    }
}
