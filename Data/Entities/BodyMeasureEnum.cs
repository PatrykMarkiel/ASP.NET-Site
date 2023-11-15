namespace WebApplication3.Data.Entities
{
    public class BodyMeasureEnum
    {
        public int Id { get; set; }
        public BodyPart name { get; set; }

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
