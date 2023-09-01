using Run_Group.Data.Enum;
using Run_Group.Data;
using Run_Group.Models;
using Microsoft.EntityFrameworkCore;
using Run_Group.Interfaces;

namespace Run_Group.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext context;

        public RaceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Add(Race race)
        {
            context.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            context.Remove(race);
            return Save();
        }

        //public async Task<IEnumerable<Race>> GetAll()
        //{
        //    return await context.Races.ToListAsync();
        //}
        // This is the same as above, but using LINQ
        public async Task<IEnumerable<Race>> GetAll()
        {
            var races = await (
                from race in context.Races
                select race
            ).ToListAsync();

            return races;
        }

        public async Task<IEnumerable<Race>> GetAllRacesByCity(string city)
        {
            return await context.Races.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public async Task<Race?> GetByIdAsync(int id)
        {
            return await context.Races.Include(i => i.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Race?> GetByIdAsyncNoTracking(int id)
        {
            return await context.Races.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Race race)
        {
            context.Update(race);
            return Save();
        }
    }
}
