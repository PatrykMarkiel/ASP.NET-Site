using System;
using WebApplication3.Data.Entities;
using WebApplication3.Models.ViewModel;
namespace  WebApplication3.Models.ViewModel
{
    public class MeasurementVm
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public DateTime TreatmentTime { get; set; }
        public DateTime InsertionTime { get; set; }
        public BodyPart? BodyPart { get; set; }
        public DateTime SafeRange { get; set; }
        public double? Value { get; set; }
        public MeasurementUnit? ValueUnit { get; set; }
        public MeasurementName MeasurementName { get; set; }
        public string UserId { get; set; }
    }
}
