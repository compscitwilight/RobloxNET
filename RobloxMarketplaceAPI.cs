using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

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

        public async static Task<RobloxAsset> GetProductInfoAsync(long assetId)
        {
            RobloxAsset Asset;
            string APILink = $"http://api.roblox.com/marketplace/productinfo?assetId={assetId}";

            using (HttpResponseMessage Response = await HTTPClient.GetAsync(APILink))
            {
                if (Response.StatusCode == HttpStatusCode.OK)
                {
                    string str = await Response.Content.ReadAsStringAsync();

                    Asset = JsonConvert.DeserializeObject<RobloxAsset>(str);
                } else
                {
                    throw new HttpRequestException($"Request to get product information from AssetId {assetId} failed. (HTTP {Response.StatusCode})");
                }
            }

            return Asset;
        }

        public async static Task<RobloxAsset> GetGamepassProductInfoAsync(long gamePassId)
        {
            RobloxAsset Gamepass;
            string APILink = $"http://api.roblox.com/marketplace/game-pass-product-info?gamePassId={gamePassId}";

            using (HttpResponseMessage Response = await HTTPClient.GetAsync(APILink))
            {
                if (Response.StatusCode == HttpStatusCode.OK)
                {
                    string str = await Response.Content.ReadAsStringAsync();

                    Gamepass = JsonConvert.DeserializeObject<RobloxAsset>(str);
                } else
                {
                    throw new HttpRequestException($"Request to get game pass product information from GamePassId {gamePassId} failed. (HTTP {Response.StatusCode})");
                }
            }

            return Gamepass;
        }
    }
}
