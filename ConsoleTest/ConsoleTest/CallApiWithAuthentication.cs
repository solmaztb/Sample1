using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace ConsoleTest
{
    public class CallApiWithAuthentication
    {
        public void CallApi()
        {
           
            //var client = new RestClient("https://localhost:2000/CasesTracker");
            //var uri = "https://easybuildapidev.johnslyng.com.au/api/CasesTracker/view/1"
            //Method 1 :
            //HttpClient httpClient = new HttpClient();
            //Token t = await GetToken(httpClient);
            //return t.AccessToken;
            //Console.WriteLine(t.AccessToken);

            //Method 2:
            //var token = await new AuthenticationService().GetAccessToken();
            //return token;
        }

        //private static async Task<Token> GetToken(HttpClient client)
        //{


        //    var form = new Dictionary<string, string>
        //    {
        //        {"grant_type", AuthConfig.GrantType},
        //        {"client_id", AuthConfig.ClientId},
        //        {"client_secret", AuthConfig.ClientSecret},
        //        {"scope",AuthConfig.Scope }
        //    };

        //    HttpResponseMessage tokenResponse = await client.PostAsync(AuthConfig.BaseAddress, new FormUrlEncodedContent(form));
        //    var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
        //    Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
        //    return tok;
        //}
        //public static async Task<Token> GetToken(Uri authenticationUrl, Dictionary<string, string> authenticationCredentials)
        //{
        //    HttpClient client = new HttpClient();

        //    FormUrlEncodedContent content = new FormUrlEncodedContent(authenticationCredentials);

        //    HttpResponseMessage response = await client.PostAsync(authenticationUrl, content);

        //    if (response.StatusCode != System.Net.HttpStatusCode.OK)
        //    {
        //        string message = String.Format("POST failed. Received HTTP {0}", response.StatusCode);
        //        throw new ApplicationException(message);
        //    }

        //    string responseString = await response.Content.ReadAsStringAsync();

        //    Token token = JsonConvert.DeserializeObject<Token>(responseString);

        //    return token;
        //}
    }
}
