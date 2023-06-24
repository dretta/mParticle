using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace mParticle.LoadGenerator
{
    public sealed class Program
    {
        public static Config config;
        public static uint requestsAvailable;

        public static async Task Main(string[] args)
        {
            string configFile = "config.json";
            if (args.Length > 0)
            {
                configFile = args[0];
            }

            config = Config.GetArguments(configFile);
            if (config == null)
            {
                Console.WriteLine("Failed to parse configuration.");
                return;
            }
            requestsAvailable = config.TargetRPS;
            uint requestId = 0;

            // TODO Do some work!
            while (requestsAvailable > 0) {
                await Post(requestId);
                requestId += 1;
            }
        }

        public static Task<HttpResponseMessage> Post(uint reqId) {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("x-api-key", config.AuthKey);

            var data = new { name = config.UserName, date = DateTime.Now.ToString(), requests_sent = reqId };
            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            requestsAvailable -= 1;
            HttpResponseMessage res = client.PostAsync(config.ServerURL, content).Result;
            requestsAvailable += 1;

            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(res.Content.ReadAsStringAsync().Result);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)res.StatusCode, res.ReasonPhrase);
            }
            return Task.FromResult(res);
        }
    }
}
