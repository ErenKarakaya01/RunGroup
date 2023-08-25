using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Run_Group.Data;
using Run_Group.Interfaces;
using Run_Group.Models;

namespace Run_Group.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            this.clubRepository = clubRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await clubRepository.GetAll();

            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Club club = await clubRepository.GetByIdAsync(id);
            return View(club);
        }
    }
}
