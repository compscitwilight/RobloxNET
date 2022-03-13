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
    public class RobloxFriendsAPI
    {
        public HttpClient HTTPClient;

        public RobloxFriendsAPI()
        {
            HTTPClient = new HttpClient();
        }

        public void Dispose()
        {
            HTTPClient.Dispose();
        }

        /*
         * Asynchronously returns an array of RobloxUsers which are the friends of the user's ID.
        */
        public async Task<RobloxUser[]> GetUsersFriendsFromIdAsync(long Id)
        {
            RobloxUser[] FriendsArr;
            string apiURL = $"http://api.roblox.com/users/{Id}/friends";

            using (HttpResponseMessage APIResponse = await HTTPClient.GetAsync(apiURL))
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
                    throw new HttpRequestException($"Request to get friend information from UserId {Id} failed.");
                }
            }

            return FriendsArr;
        }
    }
}
