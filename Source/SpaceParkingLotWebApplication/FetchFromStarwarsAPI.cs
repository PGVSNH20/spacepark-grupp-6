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
            FetchAvatarFromStarwarsAPI();
        }
        public void FetchAvatarFromStarwarsAPI()
        {
            var result = FetchAsyncFromAPI();
            result.Start();
            result.Wait();
            foreach(var el in result.Result.Data.name)
            {
                Console.WriteLine(el.ToString());
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
        }
    }
}

