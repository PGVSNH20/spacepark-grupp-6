using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using SpaceParkingLotWebApplication.Models;

namespace SpaceParkingLotWebApplication.Pages.Forms
{
    public class BeginParking : PageModel
    {


        // Lade till lite props som vi s�tter i inputs / h�mtar in fr�n Index.cshtml
        [BindProperty(SupportsGet = true)]
        public string UserGreeting { get; set; }

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
            UserGreeting = NameOFParker;
        }

        // Laddar ned en fusk-lista med skepp
        public List<StarShips> starWarsUniverseShips = FetchStarWarsShipsAsync().GetAwaiter().GetResult();
        public double GetMinutes(DateTime start, DateTime end) { double result = (end - start).TotalMinutes; return result; }
        public double GetTicketCost(double minutes, double rate) { double result = minutes * rate; return result; }
        public double TicketCost { get; set; }
        public double OccupationTime { get; set; }
        public string WrongVehicle { get; set; }
        public IActionResult OnPost()
        {

            // Laddar ned alla karakt�rer
            starWarsUniverseShips = FetchStarWarsShipsAsync().GetAwaiter().GetResult();

            // Kollar att Namnet fr�n input �r OK
            // Sedan skickar den namnet till BeginParking.cshtml
            foreach (var ship in starWarsUniverseShips)
            {
                if (ship.name.Equals(Parking.VehicleID))
                {
                    OccupationTime = GetMinutes(Parking.StartTime, Parking.Endtime);
                    TicketCost = GetTicketCost(OccupationTime, 5);
                    CreateOrder();
                    return RedirectToPage("/forms/ListStarwarsAvatars", new { UserManual = ($"{Parking.Name}, your {Parking.VehicleID} is parked and expires: {Parking.Endtime}!\n Total occupationtime: {OccupationTime} minutes \nTotal cost: {TicketCost} SEK") });
                }
            }

            // Om skeppet inte finns med i listan s� ska den ge en varning att fordonet ej �r till�tet
            WrongVehicle = $"{Parking.Name}, you need to choose a valid star ship to park in this parking lot!";
            return Page();
        }


        public void CreateOrder()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TicketContext>();

            using (TicketContext context = new TicketContext(optionsBuilder.Options))
            {
                var order = new TicketRecord()
                {
                    Name = Parking.Name,
                    VehicleID = Parking.VehicleID,
                    StartTime = Parking.StartTime,
                    EndTime = Parking.Endtime,
                    OccupationTimeInMinutes = OccupationTime,
                    AmountToPay = TicketCost,
                    ParkingSpot = new Random().Next(1, 30),
                };

                context.Add(order);
                context.SaveChanges();
            }
        }
    }
}
