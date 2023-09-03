using Microsoft.AspNetCore.Mvc;
using Run_Group.Interfaces;
using Run_Group.ViewModels;

namespace Run_Group.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository dashboardRespository;
        private readonly IPhotoService photoService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public DashboardController(IDashboardRepository dashboardRespository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            this.dashboardRespository = dashboardRespository;
            this.photoService = photoService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var userRaces = await dashboardRespository.GetAllUserRaces();
            var userClubs = await dashboardRespository.GetAllUserClubs();
            var dashboardViewModel = new DashboardViewModel()
            {
                Races = userRaces,
                Clubs = userClubs
            };
            return View(dashboardViewModel);
        }
    }
}
