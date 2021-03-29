using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EFDataAccessLibrary.Models
{
    public class TicketRecord
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName ="varchar(200)")]
        public string VehicleID { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public double OccupationTimeInMinutes { get; set; }

        [Required]
        public double AmountToPay { get; set; }

        [Required]
        public int ParkingSpot { get; set; }
    }
}
