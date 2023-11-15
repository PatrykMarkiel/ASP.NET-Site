namespace WebApplication3.Data.Entities
{
    public class DeviceEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Time { get; set; } = DateTime.Now;

    }
}
