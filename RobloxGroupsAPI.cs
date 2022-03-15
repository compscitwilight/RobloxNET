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
                    throw new HttpRequestException($"Request to get group(s) information from GroupIds {groupIds} failed. (HTTP {Response.StatusCode})");
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
                    throw new HttpRequestException($"Request to get role information from UserId {userId} failed. (HTTP {Response.StatusCode})");
                }
            }

            return Role;
        }

        public async static Task<RobloxGroupWallPost[]> GetGroupWallPostsAsync(long groupId, RobloxSortOrder sortOrder, RobloxLimit limit)
        {
            RobloxGroupWallPost[] Posts;
            string SortOrderString = sortOrder.ToString();
            string LimitValue = limit.GetHashCode().ToString();

            string APILink = $"https://groups.roblox.com/v2/groups/{groupId}/wall/posts?sortOrder={SortOrderString}&limit={LimitValue}";
            Console.WriteLine(APILink);

            using (HttpResponseMessage Response = await HTTPCLient.GetAsync(APILink))
            {
                if (Response.StatusCode == HttpStatusCode.OK)
                {
                    using (HttpContent ResponseContent = Response.Content)
                    {
                        string str = await ResponseContent.ReadAsStringAsync();

                        Posts = JsonConvert.DeserializeObject<RobloxGroupWallPost[]>(str);
                    }
                } else
                {
                    throw new HttpRequestException($"Request to get group wall information from data [{groupId},{SortOrderString},{limit}] failed. (HTTP {Response.StatusCode})");
                }
            }

            return Posts;
        }
    }
}
