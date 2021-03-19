using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkingLotWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<string> randomList = new List<string>() { "Hund", "Katt", "Yoda", "Luke Skywalker", "Arsenal" };
        public string[] randomList2 = { "Hund", "Katt", "Yoda", "Luke Skywalker", "Arsenal" };

        public void OnGet()
        {

        }
    }
}
