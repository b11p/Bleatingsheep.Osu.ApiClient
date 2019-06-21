using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApiClient;
using WebApiClient.Defaults;

namespace Bleatingsheep.Osu.ApiClient.Tests.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.WriteLine("Please provide API Key.");
            string apiKey = System.Console.ReadLine();
            var factory = OsuApiClientFactory.CreateFactory(apiKey);
            IOsuApiClient osuApiClient = factory.CreateHttpApi();
            var user = await osuApiClient.GetUser(6659067, Mode.Mania);
            var user2 = await osuApiClient.GetUser("bleatingsheep");
            var beatmaps = await osuApiClient.GetBeatmaps(Mode.Mania, false, DateTime.Now - TimeSpan.FromDays(2), 100);
            var s = await osuApiClient.GetScores(1, Mode.Standard, 100);
        }
    }
}
