using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class AuthenticationService1
    {
        public static async Task<string> GetAccessToken(IConfidentialClientApplication _app)
        {
            List<string> _scopes;
            _scopes = new List<string> { AuthConfig.Scope };
            AuthenticationResult result = null;
            //****Tried to call AcquireTokenInteractive to get the token from cache, but didnt work
            //var accounts = await _app.GetAccountsAsync();
            //try
            //{
            //    result = await _app.AcquireTokenSilent(_scopes, accounts.FirstOrDefault()).ExecuteAsync();

            //}
            //catch (MsalUiRequiredException ex)
            //{
            //    // This indicates you need to call AcquireTokenInteractive to acquire a token
            //    System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");
            //    Console.WriteLine();
            //    Console.WriteLine($"Refresh Token : {ex.Message}");
            //    try
            //    {
            //        result = await _app.AcquireTokenForClient(_scopes)
            //            .ExecuteAsync();
            //    }
            //    catch (MsalException msalex)
            //    {
            //        System.Diagnostics.Debug.WriteLine( $"Error Acquiring Token:{System.Environment.NewLine}{msalex}");
            //        Console.WriteLine();
            //        Console.WriteLine($"Access Token: {ex.Message}");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine( $"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}");
            //    return null;
            //}

            //****AcquireTokenForClient automatically refresh token after 1 hour
            result = await _app.AcquireTokenForClient(_scopes)
                .ExecuteAsync();
            Console.WriteLine(result?.AccessToken + "\n");
            return result?.AccessToken;
          
        }

        public static IConfidentialClientApplication CreateConfidentialClientApplication()
        {
            List<string> _scopes;
            IConfidentialClientApplication _app;
            _app = ConfidentialClientApplicationBuilder
                .Create(AuthConfig.ClientId)
                .WithClientSecret(AuthConfig.ClientSecret)
                .WithTenantId(AuthConfig.TenantId)
                .WithClientId(AuthConfig.ClientId)
                .Build();
            return _app;
        }
    }
}
