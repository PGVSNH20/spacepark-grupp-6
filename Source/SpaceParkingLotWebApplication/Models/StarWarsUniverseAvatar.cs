using System.Collections.Generic;

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
