using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace RobloxNET
{
    /*
     * The RobloxMarketplaceAPI class is a class that helps you work with
     * the Roblox marketplace API. Documentation on the Roblox marketplace
     * API can be linked here: https://api.roblox.com/docs#Marketplace
    */
    public static class RobloxMarketplaceAPI
    {
        private static HttpClient HTTPClient = new HttpClient();

        public static void Dispose()
        {
            HTTPClient.Dispose();
        }
    }
}
