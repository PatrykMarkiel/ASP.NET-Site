namespace WebApplication3.Data.Entities
{
    public class ProfileEntity
    {
        public  Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public int PhoneNumber { get; set; }
        public BloodType Blood { get; set; }
        public UserEntity User { get; set; }
        public string UserId { get; set; }
    }
    public enum BloodType
    {
        A_Positive,
        A_Negative,
        B_Positive,
        B_Negative,
        AB_Positive,
        AB_Negative,
        O_Positive,
        O_Negative
    }
}
