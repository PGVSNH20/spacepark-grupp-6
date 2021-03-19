using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using SpaceParkingLotWebApplication.Models;
using System.Threading.Tasks;

namespace SpaceParkingLotWebApplication
{
    [ObsoleteAttribute("This method is obsolete. Call CallNewMethod instead.", true)]
    public class FetchFromStarwarsAPI
    {
        public FetchFromStarwarsAPI()
        {
            FetchAvatarFromStarwarsAPI();
        }

        public void FetchAvatarFromStarwarsAPI()
        {
            var AvatarList = FetchAsyncFromAPI();
            AvatarList.Start();
            AvatarList.Wait();
            foreach(var el in AvatarList.Result.Data.name)
            {
                Console.WriteLine(el.ToString()); // Testar skriva ut här å ?
            }            
        }

        // Gick efter youtubevideo https://www.youtube.com/watch?v=usyI0fstrsw

        async Task<IRestResponse<StarwarsAvatar>> FetchAsyncFromAPI()
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);

            var taskCompletionSource = new TaskCompletionSource<IRestResponse<StarwarsAvatar>>();

            client.ExecuteAsync<StarwarsAvatar>(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    const string message = "Error retrieving response";
                    throw new ApplicationException(message, restResponse.ErrorException);
                }
                taskCompletionSource.SetResult(restResponse);
            });

            return await taskCompletionSource.Task;

            //var client = new RestClient("https://swapi.dev/api/");

            //var request = new RestRequest("people/", DataFormat.Json);

            //System.Threading.CancellationToken cancellationToken = default;
            //var timeline = await client.GetAsync<List<StarwarsAvatar>>(request, cancellationToken);

            //timeline.ForEach(x => Console.WriteLine(x.name)); // testa om det funkar här ?

            //return (IRestResponse<StarwarsAvatar>)timeline;
        }
    }
}

