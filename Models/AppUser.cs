using Microsoft.AspNetCore.Identity;
using Run_Group.Models;
using System.ComponentModel.DataAnnotations;

namespace Run_Group.Models
{
    public class AppUser : IdentityUser
    {
        public int? Pace { get; set; }
        public int? Mileage { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Race> Races { get; set; }
    }
}
