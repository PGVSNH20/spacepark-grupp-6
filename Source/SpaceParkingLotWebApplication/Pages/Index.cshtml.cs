using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpaceParkingLotWebApplication.Models;
using RestSharp;

namespace SpaceParkingLotWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty(SupportsGet = true)] 
        public string NameOFParker { get; set; }

        public List<StarwarsAvatar> starWarsUniverseAvatars = FetchStarWarsAvatarsAsync().Result;
        public List<StarShips> starWarsUniverseShips = FetchStarWarsShipsAsync().Result;

        static async Task<List<StarwarsAvatar>> FetchStarWarsAvatarsAsync()
        {
            List<StarwarsAvatar> avatars = new List<StarwarsAvatar>();

            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);
            var peopleResponse = await client.GetAsync<StarWarsUniverseAvatar>(request);

            foreach (var p in peopleResponse.results)
            {
                avatars.Add(p);
            }

            return avatars;
        }

        static async Task<List<StarShips>> FetchStarWarsShipsAsync()
        {
            List<StarShips> ships = new List<StarShips>();

            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("starships/", DataFormat.Json);
            var peopleResponse = await client.GetAsync<StarWarsUniverseStarShip>(request);

            foreach (var p in peopleResponse.results)
            {
                
                ships.Add(p);
            }

            return ships;
        }

        // OnClick()
        public string Message { get; set; }
        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(NameOFParker)) { NameOFParker = "Welcome Galactic Explorer!"; }
            Message = "Get used";
        }
        public void OnPost()
        {
            // Tanken är att den ska hämta data till alla Star Wars-karaktärer och skriva ut till en lista på Index.html
            Message = "Post used";

        }
    }
}
