using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkingLotWebApplication.Models
{
    public class StarWarsUniverseAvatar
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<StarwarsAvatar> results { get; set; }

    }
}
