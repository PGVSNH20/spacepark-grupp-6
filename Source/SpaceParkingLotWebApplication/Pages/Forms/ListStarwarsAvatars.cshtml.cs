using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpaceParkingLotWebApplication.Pages.Forms
{
    public class ListStarwarsAvatarsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ParkingTicket { get; set; }
        public StarwarsAvatar Avatars { get; set; }
        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(ParkingTicket)) { ParkingTicket = "Please navigate to :Want to Park!"; }
        }
    }
}
