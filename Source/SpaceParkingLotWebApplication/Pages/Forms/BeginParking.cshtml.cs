using System;
using System.Collections.Generic;
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
        public List<StarwarsAvatar> starWarsUniverseAvatars = FetchStarWarsAvatarsAsync().Result;

        static async Task<List<StarwarsAvatar>> FetchStarWarsAvatarsAsync()
        {
            List<StarwarsAvatar> avatars = new List<StarwarsAvatar>();

            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);
            var peopleResponse = await client.GetAsync<StarWarsUniverse>(request);

            foreach (var p in peopleResponse.results)
            {
                avatars.Add(p);
            }

            return avatars;
        }

        [BindProperty]
        public BeginParkingModel Parking { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid == false)
            {
                return Page();
            }
            if (starWarsUniverseAvatars.Any(x => x.name.ToLower() == Parking.Name.ToLower()))
                {
                return RedirectToPage("/index");
               }
            return RedirectToPage("/error");

            //Save Model to DataBase

            //return RedirectToPage("/index");

        }
    }
}
