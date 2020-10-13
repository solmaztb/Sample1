using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    public static class AuthConfig
    {
       // public static string BaseAddress = @"https://login.microsoftonline.com/5c1a6728-89e5-44ad-bc21-b8ff7931135a/oauth2/v2.0/token";

        public static string GrantType = "client_credentials";
        public static string ClientId = "";
        public static string ClientSecret = ".";
        public static string Scope = "";
        public static string TenantId = "";
    }
}
