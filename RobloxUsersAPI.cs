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
     * The RobloxUsersAPI class is the class used to work with
     * the Roblox users API. Documentation on the Roblox users
     * API can be linked here: https://api.roblox.com/docs#Users
    */
    public static class RobloxUsersAPI
    {
        private static HttpClient HTTPClient = new HttpClient();

        public static void Dispose()
        {
            HTTPClient.Dispose();
        }

        public async static Task<RobloxUser> GetUserFromIdAsync(int userId)
        {
            RobloxUser User;
            string APILink = $"http://api.roblox.com/users/{userId}";

            using (HttpResponseMessage APIResponse = await HTTPClient.GetAsync(APILink))
            {
                if (APIResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (HttpContent ResponseContent = APIResponse.Content)
                    {
                        string str = await ResponseContent.ReadAsStringAsync();

                        User = JsonConvert.DeserializeObject<RobloxUser>(str);
                    }
                } else
                {
                    throw new HttpRequestException($"Request to get user information from UserId {userId} failed.");
                }
            }

            return User;
        }
    }
}
