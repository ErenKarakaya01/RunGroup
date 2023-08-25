﻿using Run_Group.Data.Enum;
using Run_Group.Models;

namespace Run_Group.Interfaces
{
    public interface IRaceRepository
    {
        Task<Race?> GetByIdAsync(int id);
        Task<IEnumerable<Race>> GetAll();
        Task<IEnumerable<Race>> GetAllRacesByCity(string city);
        bool Add(Race race);
        bool Update(Race race);
        bool Delete(Race race);
        bool Save();
    }
}
