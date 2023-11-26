using System;
using WebApplication3.Data.Entities;

namespace WebApplication3.ViewModels
{
    public class MeasurementVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public DateTime TreatmentTime { get; set; }
        public DateTime InsertionTime { get; set; }
        public double Price { get; set; }
        public BodyPart BodyPartName { get; set; }        
        public DateTime SafeRange { get; set; }
        public double Value { get; set; }
        public double ValueTemplate { get; set; }
        public TestName MeasurementName { get; set; }
        public string UserId { get; set; }
    }
}
