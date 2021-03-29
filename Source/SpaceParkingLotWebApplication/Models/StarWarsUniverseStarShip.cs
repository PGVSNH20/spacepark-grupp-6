using System.Collections.Generic;

namespace SpaceParkingLotWebApplication.Models
{
    public class StarWarsUniverseStarShip
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<StarShips> results { get; set; }

    }
}