using BundleTransformer.Core.Constants;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Identity.Client;

namespace ConsoleTest
{
    class Program
    {
        private static Timer _aTimer;
        private static IConfidentialClientApplication _app;
        public static async Task Main()
        {
            //try
            //{

            //    // Method 1:
            //    var token = await new AuthenticationService1().GetAccessToken();
            //    CallApi(token);
            //    Console.ReadLine();
            //}
            //catch (HttpRequestException e)
            //{
            //    Console.WriteLine("\nException Caught!");
            //    Console.WriteLine("Message :{0} ", e.Message);
            //}
            _app = AuthenticationService1.CreateConfidentialClientApplication();

            Console.WriteLine(DateTime.Now);
            var token = await AuthenticationService1.GetAccessToken(_app);
            CallApi(token);
            Console.ReadLine();
            // StartTimer();
        }

        private static void StartTimer()
        {
            _aTimer = new System.Timers.Timer {Interval = 5000};
            _aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            _aTimer.AutoReset = true;
            // Start the timer

            _aTimer.Enabled = true;
            Console.WriteLine("Press the Enter key to exit the program... ");
            Console.ReadLine();
            Console.WriteLine("Terminating the application...");
        }
        private static async void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                // Method 1:
                Console.WriteLine(DateTime.Now);
                var token = await AuthenticationService1.GetAccessToken(_app);
                CallApi(token);
                Console.ReadLine();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }
        }
        private static void CallApi(string token)
        {
            var client = new RestClient("https://localhost:2000/CasesTracker");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {token}");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        private static string GetToken_RestClient()
        {
            var client = new RestClient("https://login.microsoftonline.com/5c1a6728-89e5-44ad-bc21-b8ff7931135a/oauth2/v2.0/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", AuthConfig.GrantType);
            request.AddParameter("client_id", AuthConfig.ClientId);
            request.AddParameter("scope", AuthConfig.Scope);
            request.AddParameter("client_secret", AuthConfig.ClientSecret);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response.Content;
        }

    }
}
