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
    public static class RobloxGroupsAPI
    {
        private static HttpClient HTTPCLient = new HttpClient();

        public static void Dispose()
        {
            HTTPCLient.Dispose();
        }

        public async static Task<RobloxGroup[]> GetGroupsAsync(long[] groupIds)
        {
            RobloxGroup[] Groups;
            string APILink = $"https://groups.roblox.com/v2/groups?groupIds={groupIds}";

            using (HttpResponseMessage Response = await HTTPCLient.GetAsync(APILink))
            {
                if (Response.StatusCode == HttpStatusCode.OK)
                {
                    using (HttpContent ResponseContent = Response.Content)
                    {
                        string str = await ResponseContent.ReadAsStringAsync();

                        Groups = JsonConvert.DeserializeObject<RobloxGroup[]>(str);
                    }
                } else
                {
                    throw new HttpRequestException($"Request to get group(s) information from GroupIds {groupIds} failed.");
                } 
            }

            return Groups;
        }

        public async static Task<RobloxGroupRole> GetRoleFromUserIdAsync(long userId)
        {
            RobloxGroupRole Role;
            string APILink = $"https://groups.roblox.com/v2/users/{userId}/groups/roles";

            using (HttpResponseMessage Response = await HTTPCLient.GetAsync(APILink))
            {
                if (Response.StatusCode == HttpStatusCode.OK)
                {
                    using (HttpContent ResponseContent = Response.Content)
                    {
                        string str = await ResponseContent.ReadAsStringAsync();

                        Role = JsonConvert.DeserializeObject<RobloxGroupRole>(str);
                    }
                } else
                {
                    throw new HttpRequestException($"Request to get role information from UserId {userId} failed.");
                }
            }

            return Role;
        }

        public async static Task<RobloxGroupWallPost[]> GetGroupWallPostsAsync(long groupId, SortOrder sortOrder, int limit)
        {
            RobloxGroupWallPost[] Post;
            string APILink = $"https://groups.roblox.com/v2/groups/{groupId}/wall/posts?sortOrder={sortOrder}&limit={limit}";
            
            using (HttpResponseMessage Response = await HTTPCLient.GetAsync(APILink))
            {
                if (Response.StatusCode == HttpStatusCode.OK)
                {
                    using (HttpContent ResponseContent = Response.Content)
                    {
                        string str = await ResponseContent.ReadAsStringAsync();

                        Post = JsonConvert.DeserializeObject<RobloxGroupWallPost[]>(str);
                    }
                } else
                {
                    throw new HttpRequestException($"Request to get group wall information from data [{groupId},{sortOrder},{limit}] failed.");
                }
            }

            return Post;
        }
    }
}
