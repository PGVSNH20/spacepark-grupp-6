using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkingLotWebApplication.Models
{
    public class BeginParkingModel
    {
        public string Name { get; set; }

        public int VehicleID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime Endtime { get; set; }
    }
}
