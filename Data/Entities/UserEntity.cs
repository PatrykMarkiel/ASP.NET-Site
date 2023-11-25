using Microsoft.AspNetCore.Identity;
namespace WebApplication3.Data.Entities
{
    public class UserEntity : IdentityUser
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public UserType UserTypename { get; set; }
        public ProfileEntity Profile { get; set; }  
        public int ProfileId { get; set; }
        public ICollection<MeasurementEntity> Measurement { get; set; }
        public ICollection<DeviceEntity> Device { get; set; }

    }
    public enum UserType
    {
        SuperAdmin,
        Admin,
        Client
    }
}
