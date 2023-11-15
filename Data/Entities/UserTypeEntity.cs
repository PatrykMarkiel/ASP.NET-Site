namespace WebApplication3.Data.Entities
{
    public class UserTypeEntity
    {
        public Guid Id { get; set; }
        public UserType name { get; set; }

    }
    public enum UserType
    {
        SuperAdmin,
        Admin,
        Client
    }
}
