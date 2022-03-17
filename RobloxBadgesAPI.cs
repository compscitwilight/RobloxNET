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
    public static class RobloxBadgesAPI
    {
        private static HttpClient HTTPClient = new HttpClient();

        public async static Task<RobloxBadge> GetBadgeInfoAsync(long badgeId)
        {
            RobloxBadge Badge;
            string APILink = $"https://badges.roblox.com/v1/badges/{badgeId}";

            using (HttpResponseMessage Response = await HTTPClient.GetAsync(APILink))
            {
                if (Response.StatusCode == HttpStatusCode.OK)
                {
                    using (HttpContent APIContent = Response.Content)
                    {
                        string str = await APIContent.ReadAsStringAsync();

                        Badge = JsonConvert.DeserializeObject<RobloxBadge>(str);
                    }
                } else
                {
                    throw new HttpRequestException($"Request to get group badge information from BadgeId {badgeId} failed. (HTTP {Response.StatusCode})");
                }
            }

            return Badge;
        }

        public async static Task<RobloxBadgeMetadata> GetBadgesMetadataAsync()
        {
            RobloxBadgeMetadata Metadata;
            string APILink = "https://badges.roblox.com/v1/badges/metadata";

            using (HttpResponseMessage Response = await HTTPClient.GetAsync(APILink))
            {
                if (Response.StatusCode == HttpStatusCode.OK)
                {
                    using (HttpContent APIContent = Response.Content)
                    {
                        string str = await APIContent.ReadAsStringAsync();

                        Metadata = JsonConvert.DeserializeObject<RobloxBadgeMetadata>(str);
                    }
                } else
                {
                    throw new HttpRequestException($"Request to get badges metadata from API {APILink} failed. (HTTP {Response.StatusCode})");
                }
            }

            return Metadata;
        }

        public static async Task<int> GetFreeBadgesQuotaFromUniverseIdAsync(long universeId)
        {
            int Quota;
            string APILink = $"https://badges.roblox.com/v1/universes/{universeId}/free-badges-quota";

            using (HttpResponseMessage Response = await HTTPClient.GetAsync(APILink))
            {
                if (Response.StatusCode == HttpStatusCode.OK)
                {
                    using (HttpContent APIContent = Response.Content)
                    {
                        string str = await APIContent.ReadAsStringAsync();

                        Quota = JsonConvert.DeserializeObject<int>(str);
                    }
                } else
                {
                    throw new HttpRequestException($"Request to get free badges quota from UniverseId {universeId} failed. (HTTP {Response.StatusCode})");
                }
            }

            return Quota;
        }
    }
}
