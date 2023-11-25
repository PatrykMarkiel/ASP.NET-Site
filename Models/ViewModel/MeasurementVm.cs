using System;
using WebApplication3.Data.Entities;

namespace WebApplication3.ViewModels
{
    public class MeasurementVm
    {
        public int MeasurementId { get; set; }
        public string MeasurementName { get; set; }
        public string MeasurementComment { get; set; }
        public DateTime MeasurementTreatmentTime { get; set; }
        public DateTime MeasurementInsertionTime { get; set; }
        public double MeasurementPrice { get; set; }
        public BodyPart MeasurementBodyPartName { get; set; }
        public Guid TestTypeId { get; set; }
        public string TestTypeName { get; set; }
        public string TestTypeDescription { get; set; }
        public string TestTypeComment { get; set; }
        public DateTime TestTypeSafeRange { get; set; }
        public double TestTypeValue { get; set; }
        public double TestTypeValueTemplate { get; set; }
        public TestName TestTypeMeasurementName { get; set; }
        public string UserId { get; set; }
    }
}
