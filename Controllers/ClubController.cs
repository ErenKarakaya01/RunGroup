using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Run_Group.Data;
using Run_Group.Models;

namespace Run_Group.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext context;

        public ClubController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Club> clubs = context.Clubs.ToList();

            return View(clubs);
        }

        public IActionResult Detail(int id)
        {
            Club club = context.Clubs.Include(a => a.Address).FirstOrDefault(club => club.Id == id);
            return View(club);
        }
    }
}
