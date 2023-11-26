namespace WebApplication3.Data.Entities
{
    public class MeasurementEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";       
        public string Comment { get; set; } = ""; 
        public string Description { get; set; } = "";
        public double Value { get; set; }
        public double ValueTemplate { get; set; }
        public double Price { get; set; }
        public DateTime TreatmentTime { get; set; }
        public DateTime InsertionTime { get; set; }
        public DateTime SafeRange { get; set; }
        public TestName MeasurementName { get; set; }
        public BodyPart BodyPartName { get; set; }
        public UserEntity User { get; set; }
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
    public enum TestName
    {
        Pulse,
        Height,
        Weight,
        Saturation,
        BodyMeasure,
        Observation,
        Accident,
        Procedure
    }
}

