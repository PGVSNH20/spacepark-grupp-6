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
		public decimal cost_in_credits { get; set; }
		public double length { get; set; }
		public int max_atmosphering_speed { get; set; }
		public int crew { get; set; }
		public int passengers { get; set; }
		public int cargo_capacity { get; set; }
		public string consumables { get; set; }
		public double hyperdrive_rating { get; set; }
		public int MGLT { get; set; }
		public string starship_class { get; set; }
		public List<string> pilots { get; set; }
		public List<string> films { get; set; }
		public DateTime created { get; set; }
		public DateTime edited { get; set; }
		public List<string> url { get; set; }
	}
}
