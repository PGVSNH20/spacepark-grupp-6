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

        // Lade till lite props som vi s�tter i inputs / h�mtar in fr�n Index.cshtml

        private BeginParkingModel _parking;

        [BindProperty]
        public string Vehicle { get; set; }

        [BindProperty]
        public DateTime EndTime { get; set; }

        [BindProperty]
        public DateTime StartTime { get; set; } = DateTime.Now;

        [BindProperty(SupportsGet = true)]
        public string NameOFParker { get; set; }

        [BindProperty]
        public BeginParkingModel Parking
        {
            get { return _parking; }   // get method

            set
            {
                _parking = value;
                value.Name = NameOFParker;
                value.VehicleID = Vehicle;
                value.StartTime = StartTime;
                value.Endtime = EndTime;
            }  // S�tter alla v�rderna till Datamodellen BeginParkingModel
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



        public void OnGet()
        {
        }

        // Laddar ned en fusk-lista med skepp
        public List<StarShips> starWarsUniverseShips = FetchStarWarsShipsAsync().Result;

        public IActionResult OnPost()
        {
            // Laddar ned alla karakt�rer
            starWarsUniverseShips = FetchStarWarsShipsAsync().Result;

            // Kollar att Namnet fr�n input �r OK
            // Sedan skickar den namnet till BeginParking.cshtml
            foreach (var ship in starWarsUniverseShips)
            {
                if (ship.name.Equals(Parking.VehicleID))
                {
                    return RedirectToPage("/forms/ListStarwarsAvatars", new { ParkingTicket = ($"{Parking.Name}, your {Parking.VehicleID} is parked and expires: {Parking.Endtime}!") });
                }
            }

            // Om skeppet inte finns med i listan s� ska den kanske ge en varning
            // att man inte tar emot skeppet p� parkeringen?
            // MEN i dagsl�get resettar den bara sidan BeginParking.cshtml
            return Page();


            //Save Model to DataBase
            //"Parking"-objectet l�r v�ll vara det som ska in i databasen? -DR
        }
    }
}
