using System.ComponentModel.DataAnnotations;
using WebApplication3.Data.Entities;

namespace WebApplication3.Models.ViewModel
{
    public class ProfileVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public BloodType Blood { get; set; }
        public string UserId { get; set; }
    }
}
