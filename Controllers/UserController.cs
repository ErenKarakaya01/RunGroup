using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Run_Group.Interfaces;
using Run_Group.Models;
using Run_Group.Repository;
using Run_Group.ViewModels;

namespace Run_Group.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<AppUser> userManager;
        private readonly IPhotoService photoService;

        public UserController(IUserRepository userRepository, UserManager<AppUser> userManager, IPhotoService photoService)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.photoService = photoService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    Pace = user.Pace,
                    Mileage = user.Mileage,
                    UserName = user.UserName,
                };
                result.Add(userViewModel);
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var user = await userRepository.GetUserById(id);
            if (user == null)
            {
                return RedirectToAction("Index", "Users");
            }

            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                Pace = user.Pace,
                Mileage = user.Mileage,
                UserName = user.UserName,
            };
            return View(userDetailViewModel);
        }
    }
}
