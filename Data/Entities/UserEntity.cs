namespace WebApplication3.Data.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Phonenumber { get; set; } = "";
        public UserType UserTypename { get; set; }
        public MeasurementEntity Measurement { get; set; }

    }
    public enum UserType
    {
        SuperAdmin,
        Admin,
        Client
    }
}
