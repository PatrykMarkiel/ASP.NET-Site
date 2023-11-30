using System;
using System.Collections.Generic;
using WebApplication3.Data.Entities;

namespace WebApplication3.Models.ViewModels
{
    public class DeviceMeasurementProfileViewModel
    {
        public List<DeviceEntity> Devices { get; set; }
        public List<MeasurementEntity> Measurements { get; set; }
        public ProfileEntity Profile { get; set; }
    }
}