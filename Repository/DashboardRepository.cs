using Run_Group.Data;
using Run_Group.Interfaces;
using Run_Group.Models;

namespace Run_Group.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Club>> GetAllUserClubs()
        {
            var curUser = httpContextAccessor.HttpContext?.User.GetUserId();
            var userClubs = context.Clubs.Where(r => r.AppUser.Id == curUser);
            return userClubs.ToList();
        }

        public async Task<List<Race>> GetAllUserRaces()
        {
            var curUser = httpContextAccessor.HttpContext?.User.GetUserId();
            var userRaces = context.Races.Where(r => r.AppUser.Id == curUser);
            return userRaces.ToList();
        }

    }
}
