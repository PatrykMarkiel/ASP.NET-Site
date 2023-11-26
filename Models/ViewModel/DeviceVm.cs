using System.ComponentModel.DataAnnotations;
using WebApplication3.Data.Entities;

namespace WebApplication3.Models.ViewModel
{
    public class DeviceVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";

        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime Time { get; set; }
        public string UserId { get; set; }
        public DeviceType DeviceName { get; set; }
    }
}
