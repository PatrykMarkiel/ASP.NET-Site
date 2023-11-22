using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Data.Entities
{
    public class ProfileEntity
    {
        public  Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public BloodType Blood { get; set; }
        public UserEntity User { get; set; }
        public string UserId { get; set; }
    }
    public enum BloodType
    {
        [Display(Name = "A RH+")]
        A_Positive,
        [Display(Name = "A RH-")]
        A_Negative,
        [Display(Name = "B RH+")]
        B_Positive,
        [Display(Name = "B RH-")]
        B_Negative,
        [Display(Name = "AB RH+")]
        AB_Positive,
        [Display(Name = "AB RH-")]
        AB_Negative,
        [Display(Name = "0 RH+")]
        O_Positive,
        [Display(Name = "0 RH-")]
        O_Negative,
        [Display(Name = "To check")]
        ToCheck
    }
}
