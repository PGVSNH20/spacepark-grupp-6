using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using SpaceParkingLotWebApplication;
using SpaceParkingLotWebApplication.Models;
using System;
using System.Threading.Tasks;

namespace SpaceParkTestUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WhenFetchingStarWarsData_Expect_True_IsSuccessfullAsync()
        {
            var restClient = new RestClient("https://swapi.dev/api/");
            var restRequest = new RestRequest("people/", DataFormat.Json);
            var peopleResponse = restClient.Get(restRequest);
            Console.WriteLine(peopleResponse.IsSuccessful);
            Console.WriteLine(peopleResponse.StatusCode);

            Assert.IsTrue(peopleResponse.IsSuccessful);
        }

        [TestMethod]
        public async Task WhenFetchingStarWarsData_With_Class_StarWarsUniverse_Expect_Count_Bigger_Than_Zero()
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);
            var peopleResponse = await client.GetAsync<StarWarsUniverse>(request);
            Console.WriteLine(peopleResponse.results.Count);

            Assert.IsTrue(peopleResponse.results.Count > 0);
        }

        [TestMethod]
        public async Task WhenFetchingStarWarsData_With_Class_StarWarsUniverse_Expect_Luke_SkyWalker()
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("people/", DataFormat.Json);
            var peopleResponse = await client.GetAsync<StarWarsUniverse>(request);

            Assert.AreEqual("Luke Skywalker", peopleResponse.results[0].name);
        }
    }
}
