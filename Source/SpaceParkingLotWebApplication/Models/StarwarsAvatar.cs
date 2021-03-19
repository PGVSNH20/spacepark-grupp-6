using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkingLotWebApplication
{
    public class StarwarsAvatar
    {
        public List<StarwarsAvatar> Data { get; set; }

        public string name { get; set; }
        public int height { get; set; }
        public int mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public Uri[] films { get; set; }
        public Uri[] species { get; set; }
        public Uri[] vehicles { get; set; }
        public Uri[] starships { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public Uri url { get; set; }

    }
}
