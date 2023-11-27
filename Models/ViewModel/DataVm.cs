using WebApplication3.Data.Entities;
using WebApplication3.Models.ViewModel;
namespace WebApplication3.Models.ViewModel
{
    public class DataVm
    {
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public double? BodyCircumference { get; set; }
        public double? BMI { get; set; }
        public int? HeartRate { get; set; }
        public int? Saturation { get; set; }
        public DateTime TreatmentTime { get; set; }
        public DateTime InsertionTime { get; set; }
        public BodyPart? BodyPart { get; set; }
        public DateTime SafeRange { get; set; }
        public double? Value { get; set; }
        public MeasurementName MeasurementName { get; set; }
        public BloodType Blood { get; set; }
        public string UserId { get; set; }
    }
}
