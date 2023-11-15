namespace WebApplication3.Data.Entities
{
    public class TestTypeEnum
    {
        public Guid Id { get; set; }
        public TestName name { get; set; }

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
