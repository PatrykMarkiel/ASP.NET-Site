using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Data.Entities
{
    public class MeasurementEntity
    {
        public Guid Id { get; set; }   
        public string Comment { get; set; } = ""; 
        public string Description { get; set; } = "";
        public double? Value { get; set; }
        public MeasurementUnit? ValueUnit { get; set; }
        public DateTime TreatmentTime { get; set; }
        public DateTime InsertionTime { get; set; }
        public DateTime SafeRange { get; set; }
        public MeasurementName MeasurementName { get; set; }
        public BodyPart? BodyPart { get; set; }
        public UserEntity? User { get; set; }
        public string UserId { get; set; }
    }
    public enum BodyPart
    {
        Neck,
        Arm,
        Forearm,
        Chest,
        Waist,
        Hips,
        Thighs,
        Calf
    }
    public enum MeasurementName
    {
        Pulse,
        Height,
        Weight,
        Saturation,
        BodyMeasure,
        Observation
    }
    public enum MeasurementUnit
    {
        [Display(Name = "bpm")]
        Pulse = 1,

        [Display(Name = "cm")]
        Height = 2,

        [Display(Name = "kg")]
        Weight = 3,

        [Display(Name = "%")]
        Saturation = 4,

        [Display(Name = "cm")]
        BodyMeasure = 5
    }
}

