using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Data.Entities
{
    public class DeviceEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Time { get; set; } = DateTime.Now;
        public UserEntity User { get; set; }
        public string UserId { get; set; }

    }
}
