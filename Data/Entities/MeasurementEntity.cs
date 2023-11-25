namespace WebApplication3.Data.Entities
{
    public class MeasurementEntity
    {
        public int Id { get; set; }
 
        public string Name { get; set; } = "";       
        public string comment { get; set; } = "";
        public DateTime TreatmentTime { get; set; }
        public DateTime InsertionTime { get; set; }
        public double Price { get; set; }
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

}
