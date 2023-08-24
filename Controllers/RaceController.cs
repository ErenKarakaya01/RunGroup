using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Run_Group.Data;
using Run_Group.Models;

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
    }
}
