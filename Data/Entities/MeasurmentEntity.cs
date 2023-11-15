namespace WebApplication3.Data.Entities
{
    public class MeasurmentEntity
    {
        public Guid Id { get; set; }
 
        public string Name { get; set; } = "";       //<-enum?
        public string comment { get; set; } = "";
        public DateTime TreatmentTime { get; set; }
        public DateTime InsertionTime { get; set; } = DateTime.Now;
        public double Value { get; set; } 
    }
}
