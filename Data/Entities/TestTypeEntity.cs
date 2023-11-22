using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Data.Entities
{
    public class TestTypeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; } = "";      
        public string Description { get; set; } = "";
        public string comment { get; set; } = "";
        public DateTime Saferange{ get; set; }
        public double Value { get; set; }
        public double ValueTemplate { get; set; }
        public TestName MeasurementName { get; set; }

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
