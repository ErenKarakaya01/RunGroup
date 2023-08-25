﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Run_Group.Data;
using Run_Group.Interfaces;
using Run_Group.Models;

namespace Run_Group.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository raceRepository;

        public RaceController(IRaceRepository raceRepository)
        {
            this.raceRepository = raceRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await raceRepository.GetAll();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Race race = await raceRepository.GetByIdAsync(id);
            return View(race);
        }
    }
}
