using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkingLotWebApplication
{
    public class FetchFromStarwarsAPI
    {
        public FetchFromStarwarsAPI()
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);
            // NOTE: The Swreponse is a custom class which represents the data returned by the API, RestClient have buildin ORM which maps the data from the reponse into a given type of object
            var peopleResponse = await client.GetAsync<StarwarsAvatar>(request);

            Console.WriteLine(peopleResponse.Data.Count);
            foreach (var p in peopleResponse.Data.Results)
            {
                Console.WriteLine(p.Name);
            }
        }       
    }
}

