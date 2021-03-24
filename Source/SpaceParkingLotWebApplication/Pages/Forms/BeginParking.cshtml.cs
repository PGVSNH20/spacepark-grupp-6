using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;
using SpaceParkingLotWebApplication.Models;

namespace SpaceParkingLotWebApplication.Pages.Forms
{
    public class BeginParking : PageModel
    {
        static async Task<List<StarwarsAvatar>> FetchStarWarsAvatarsAsync()
        {
            List<StarwarsAvatar> avatars = new List<StarwarsAvatar>();

            int currentPage = 1;
            bool isThereAnotherPage = true;

            var client = new RestClient("https://swapi.dev/api/people/");

            while (isThereAnotherPage)
            {
                var request = new RestRequest($"?page={currentPage}", DataFormat.Json);
                var peopleResponse = await client.GetAsync<StarWarsUniverseAvatar>(request);

                foreach (var p in peopleResponse.results)
                {
                    avatars.Add(p);
                    Console.WriteLine("Added: " + p.name);
                }

                if (peopleResponse.next != null)
                {
                    currentPage++;
                }

                else
                {
                    isThereAnotherPage = false;
                }
            }

            return avatars;
        }

        static async Task<List<StarShips>> FetchStarWarsShipsAsync()
        {
            List<StarShips> ships = new List<StarShips>();

            int currentPage = 1;
            bool isThereAnotherPage = true;

            var client = new RestClient("https://swapi.dev/api/starships/");

            while (isThereAnotherPage)
            {
                var request = new RestRequest($"?page={currentPage}", DataFormat.Json);
                var peopleResponse = await client.GetAsync<StarWarsUniverseStarShip>(request);

                foreach (var p in peopleResponse.results)
                {
                    ships.Add(p);
                    Console.WriteLine("Added: " + p.name);
                }

                if (peopleResponse.next != null)
                {
                    currentPage++;
                }

                else
                {
                    isThereAnotherPage = false;
                }
            }
            return ships;
        }

        [BindProperty]
        public BeginParkingModel Parking { get; set; }

        [BindProperty]
        public DateTime Time { get; set; } = DateTime.Now;

        public void OnGet()
        {
        }
        
        public bool chooseShip { get; set; } = false;

        public List<StarShips> starWarsUniverseShips { get; set; }
        public List<StarwarsAvatar> starWarsUniverseAvatars { get; set; }
        public IActionResult OnPost()
        {
            starWarsUniverseAvatars = FetchStarWarsAvatarsAsync().Result;
            
            if (ModelState.IsValid == false)
            {
                if (Parking.Name != null)
                {
                    if (starWarsUniverseAvatars.Any(x => x.name.ToLower() == Parking.Name.ToLower()))
                    {
                        Parking.StartTime = Time; // Kanske s�tta den h�r i slutet av ledet om man faktiskt k�per biljetten.
                        starWarsUniverseShips = FetchStarWarsShipsAsync().Result;
                        chooseShip = true;
                        //return RedirectToPage("/index", new { NameOfParker = ($"{Parking.Name}, your parking expires: {Parking.Endtime}!") });                
                    }
                }               
                return Page(); // Vad g�r den h�r ? Den h�r k�rs nu ist�llet f�r n�sta if sats...
            }           
            return RedirectToPage("/error");

            //Save Model to DataBase

            //return RedirectToPage("/index");
        }
    }
}
