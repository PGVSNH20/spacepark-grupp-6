using System;

namespace SpaceParkingLotWebApplication.Models
{
    public class BeginParkingModel
    {
        public string Name { get; set; }

        public string VehicleID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime Endtime { get; set; }
    }
}
