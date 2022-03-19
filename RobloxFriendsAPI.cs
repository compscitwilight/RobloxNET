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
     * Class for working with the Roblox friends API. Documentation for the 
     * Roblox friends API can be linked here, https://api.roblox.com/docs#Friends
    */
    public static class RobloxFriendsAPI
    {
        private static HttpClient HTTPClient = new HttpClient();

        public static void Dispose()
        {
            HTTPClient.Dispose();
        }

        public async static Task<RobloxFriendsMetadata> GetFriendsMetadata(long targetUserId)
        {
            RobloxFriendsMetadata Metadata;
            string APILink = $"https://friends.roblox.com/v1/metadata?targetUserId={targetUserId}";

            using (HttpResponseMessage APIResponse = await HTTPClient.GetAsync(APILink))
            {
                if (APIResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (HttpContent ResponseContent = APIResponse.Content)
                    {
                        string str = await ResponseContent.ReadAsStringAsync();

                        Metadata = JsonConvert.DeserializeObject<RobloxFriendsMetadata>(str);
                    }
                }
                else
                {
                    throw new HttpRequestException($"Request to get friend metadata from UserId {targetUserId} failed. (HTTP {APIResponse.StatusCode})");
                }
            }

            return Metadata;
        }

        /*
         * Asynchronously returns an array of RobloxUsers which are the friends of the user's ID.
        */
        public async static Task<RobloxUser[]> GetUsersFriendsFromIdAsync(long Id)
        {
            RobloxUser[] FriendsArr;
            string APILink = $"http://api.roblox.com/users/{Id}/friends";

            using (HttpResponseMessage APIResponse = await HTTPClient.GetAsync(APILink))
            {
                if (APIResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (HttpContent ResponseContent = APIResponse.Content)
                    {
                        string str = await ResponseContent.ReadAsStringAsync();
                        
                        FriendsArr = JsonConvert.DeserializeObject<RobloxUser[]>(str);
                    }
                } else
                {
                    throw new HttpRequestException($"Request to get friend information from UserId {Id} failed. (HTTP {APIResponse.StatusCode})");
                }
            }
            
            return FriendsArr;
        }
    }
}
