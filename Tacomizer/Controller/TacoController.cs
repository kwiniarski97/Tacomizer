using System.Threading.Tasks;
using Tacomizer.Model;

namespace Tacomizer.Controller
{
    using RestSharp;

    public class TacoController
    {
        private static RestClient _restClient = new RestClient("http://taco-randomizer.herokuapp.com/");

        public static async Task<Response> GetRandomTaco()
        {
            var request = new RestRequest("random", Method.GET);
            var asyncResponse =  await _restClient.ExecuteTaskAsync<Response>(request);
            var data = asyncResponse.Data;
            return data;
        }
    }
}