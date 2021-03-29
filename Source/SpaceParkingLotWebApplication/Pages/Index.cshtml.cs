using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpaceParkingLotWebApplication.Models;
using RestSharp;
using EFDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary.Models;

namespace SpaceParkingLotWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TicketContext _db;

        public IndexModel(ILogger<IndexModel> logger, TicketContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void LoadStoredTickets()
        {
            if (_db.Tickets.Count() == 0)
            {
                Console.WriteLine("theres nothing in this table");
            }
        }
        // Laddar ned en fusk-lista med karaktärer
        public List<StarwarsAvatar> starWarsUniverseAvatars = FetchStarWarsAvatarsAsync().GetAwaiter().GetResult();
        
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
        [BindProperty]
        public string ActiveTickets { get; set; }
        [BindProperty]
        public string NameOFParker { get; set; }

        [BindProperty(SupportsGet = true)]
        public string InvalidName { get; set; }

        // OnClick()
        public List<TicketRecord> AllTicketsInDb;

        public void OnGet()
        {
           var tickets = _db.Tickets
                            .ToList();
            AllTicketsInDb = tickets;
            /*foreach(var ticket in tickets)
            {
                Console.WriteLine(@"ID{ ticket.Id} Name:
                { ticket.Name} Parkingspot:
                { ticket.ParkingSpot} Vehicle:
                { ticket.VehicleID} Endtime:
                { ticket.EndTime}");
                activeTicketsInDb = tickets;
            } */
        }


        public IActionResult OnPost()
        {
            // Laddar ned alla karaktärer
            starWarsUniverseAvatars = FetchStarWarsAvatarsAsync().GetAwaiter().GetResult(); 
            // https://youtu.be/J0mcYVxJEl0?t=2475 Exceptions bakas in med .Result därför ska man använda detta istället.

            // Kollar att Namnet från input är OK
            // Sedan skickar den namnet till BeginParking.cshtml
            foreach (var avatar in starWarsUniverseAvatars)
            {
                if (avatar.name == NameOFParker)
                {
                    return RedirectToPage("/forms/BeginParking", new { NameOFParker = NameOFParker });
                }
            }

            // Om namnet inte finns med i listan så går den tillbaka till index.cshtml
            return RedirectToPage("/index", new { InvalidName = $"Hey Stranger, identify yourself!" });
        }
    }
}
