using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkingLotWebApplication.Models
{
    public class StarShips
    {
		public string name { get; set; }
		public string model { get; set; }
		public string manufacturer { get; set; }
		public string cost_in_credits { get; set; }
		public decimal length { get; set; }
		public string max_atmosphering_speed { get; set; }
		public string crew { get; set; }
		public string passengers { get; set; }
		public long cargo_capacity { get; set; }
		public string consumables { get; set; }
		public string hyperdrive_rating { get; set; }
		public int MGLT { get; set; }
		public string starship_class { get; set; }
		public List<Uri> pilots { get; set; }
		public List<Uri> films { get; set; }
		public DateTime created { get; set; }
		public DateTime edited { get; set; }
		public List<Uri> url { get; set; }
	}
}
