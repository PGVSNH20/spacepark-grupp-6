using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.Models
{
    public class TicketRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double OccupationTimeInMinutes { get; set; }
        public double AmountToPay { get; set; }
        public int ParkingSpot { get; set; } = 1;
    }
}
