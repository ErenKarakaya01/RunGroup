using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Run_Group.Data;
using Run_Group.Models;
using Run_Group.Repository;

namespace Run_Group.Controllers
{
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext context;

        public RaceController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Race> races = context.Races.ToList();
            return View(races);
        }

        public IActionResult Detail(int id)
        {
            Race race = context.Races.Include(a => a.Address).FirstOrDefault(club => club.Id == id);
            return View(race);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Race race)
        {
            if (!ModelState.IsValid)
            {
                return View(race);
            }

            raceRepository.Add(race);
            return RedirectToAction("Index");
        }
    }
}
