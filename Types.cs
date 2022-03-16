using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxNET
{
    /*
     * The RobloxAsset class is meant to contain Roblox asset data that is sent 
     * by the Roblox API.
    */
    public class RobloxAsset
    {
        public RobloxAsset(
            long TargetId, 
            string ProductType, 
            long AssetId, 
            long ProductId, 
            string Name, 
            string Description, 
            long AssetTypeId, 
            RobloxAssetCreator Creator, 
            long IconImageAssetId, 
            DateTime Created, 
            DateTime Updated, 
            int? PriceInRobux, 
            int? PriceInTickets, 
            int Sales, 
            bool IsNew, 
            bool IsForSale, 
            bool IsPublicDomain, 
            bool IsLimited, 
            bool IsLimitedUnique, 
            int? Remaining, 
            int MinimumMembershipLevel
            )
        {
            this.TargetId = TargetId;
            this.ProductType = ProductType;
            this.AssetId = AssetId;
            this.ProductId = ProductId;
            this.Name = Name;
            this.Description = Description;
            this.AssetTypeId = AssetTypeId;
            this.Creator = Creator;
            this.IconImageAssetId = IconImageAssetId;
            this.Created = Created;
            this.Updated = Updated;
            this.PriceInRobux = PriceInRobux;
            this.PriceInTickets = PriceInTickets;
            this.Sales = Sales;
            this.IsNew = IsNew;
            this.IsForSale = IsForSale;
            this.IsPublicDomain = IsPublicDomain;
            this.IsLimited = IsLimited;
            this.IsLimitedUnique = IsLimitedUnique;
            this.Remaining = Remaining;
            this.MinimumMembershipLevel = MinimumMembershipLevel;
        }

        public long TargetId { get; set; }
        public string ProductType { get; set; }
        public long AssetId { get; set; }
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long AssetTypeId { get; set; }
        public RobloxAssetCreator Creator { get; set; }
        public long IconImageAssetId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int? PriceInRobux { get; set; }
        public int? PriceInTickets { get; set; }
        public int Sales { get; set; }
        public bool IsNew { get; set; }
        public bool IsForSale { get; set; }
        public bool IsPublicDomain { get; set; }
        public bool IsLimited { get; set; }
        public bool IsLimitedUnique { get; set; }
        public int? Remaining { get; set; }
        public int MinimumMembershipLevel { get; set; }
    }

    /*
     * The RobloxAssetCreator class is meant to contain creator data. 
    */
    public class RobloxAssetCreator
    {
        public RobloxAssetCreator(long Id, string Username, string CreatorType, long CreatorTargetId)
        {
            this.Id = Id;
            this.Username = Username;
            this.CreatorType = CreatorType;
            this.CreatorTargetId = CreatorTargetId;
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string CreatorType { get; set; }
        public long CreatorTargetId { get; set; }
    }

    /*
     * The RobloxAssetVersion class is meant to contain Roblox asset version data 
     * that is sent by the Roblox API. A RobloxAssetVersion is the version of the asset
     * ,you can use it with the API here: api.roblox.com/assets/{id}/versions
    */
    public class RobloxAssetVersion
    {
        public RobloxAssetVersion(
            long Id, 
            long AssetId, 
            int VersionNumber, 
            long ParentAssetVersionId, 
            int CreatorType, 
            long CreatorTargetId, 
            long? CreatingUniverseId, 
            DateTime Created, 
            DateTime Updated
            )
        {
            this.Id = Id;
            this.AssetId = AssetId;
            this.VersionNumber = VersionNumber;
            this.ParentAssetVersionId = ParentAssetVersionId;
            this.CreatorType = CreatorType;
            this.CreatorTargetId = CreatorTargetId;
            this.CreatingUniverseId = CreatingUniverseId;
            this.Created = Created;
            this.Updated = Updated;
        }

        public long Id { get; set; }
        public long AssetId { get; set; }
        public int VersionNumber { get; set; }
        public long ParentAssetVersionId { get; set; }
        public int CreatorType { get; set; }
        public long CreatorTargetId { get; set; }
        public long? CreatingUniverseId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }

    /*
     * The RobloxUser class is meant to contain Roblox user data that is sent   
     * by the Roblox API.
    */
    public class RobloxUser
    {
        public RobloxUser(
            long Id, 
            string Username, 
            string? AvatarUri, 
            bool AvatarFinal, 
            bool IsOnline
            )
        {
            // Setting the properties of the RobloxUser class from the constructor paramters

            this.Id = Id;
            this.Username = Username;
            this.AvatarUri = AvatarUri;
            this.AvatarFinal = AvatarFinal;
            this.IsOnline = IsOnline;
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string? AvatarUri { get; set; }
        public bool AvatarFinal { get; set; }
        public bool IsOnline { get; set; }
    }

    /*
     * RobloxCanManage is meant to contain data for the GetUserCanManageAsync in
     * the RobloxUsersAPI.
    */
    public class RobloxCanManage
    {
        public RobloxCanManage(bool Success, bool CanManage)
        {
            this.Success = Success;
            this.CanManage = CanManage;
        }

        public bool Success { get; set; }
        public bool CanManage { get; set; }
    }

    /*
     * The RobloxGroup class is meant to contain data for Roblox groups. 
     * Documentation for Roblox groups can be linked here: https://groups.roblox.com/docs#
    */
    public class RobloxGroup
    {
        public RobloxGroup(
            long id, 
            string name, 
            string description,
            RobloxGroupOwner owner, 
            int memberCount, 
            DateTime created
            )
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.owner = owner;
            this.memberCount = memberCount;
            this.created = created;
        }

        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public RobloxGroupOwner owner { get; set; }
        public int memberCount { get; set; }
        public DateTime created { get; set; }
    }
    
    /*
     * The RobloxGroupOwner class is meant to contain data for the owner of 
     * a RobloxGroup.
    */
    public class RobloxGroupOwner
    {
        public RobloxGroupOwner(long id, string type, string name)
        {
            this.id = id;
            this.type = type;
            this.name = name;
        }

        public long id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
    }

    /*
     * The RobloxGroupRole class is meant to contain data for group roles. 
    */
    public class RobloxGroupRole
    {
        public RobloxGroupRole(long id, string name, byte rank)
        {
            this.id = id;
            this.name = name;
            this.rank = rank;
        }

        public long id { get; set; }
        public string name { get; set; }
        public byte rank { get; set; }
    }

    /*
     * The RobloxGroupWallPost class is meant to contain data for group wall posts 
    */
    public class RobloxGroupWallPost
    {
        public RobloxGroupWallPost(
            string? previousPageCursor, 
            string nextPageCursor, 
            long id, 
            RobloxGroupWallPoster poster, 
            string body, 
            DateTime created, 
            DateTime updated
            )
        {
            this.previousPageCursor = previousPageCursor;
            this.nextPageCursor = nextPageCursor;
            this.id = id;
            this.poster = poster;
            this.body = body;
            this.created = created;
            this.updated = updated;
        }

        public string? previousPageCursor { get; set; }
        public string nextPageCursor { get; set; }
        public long id { get; set; }
        public RobloxGroupWallPoster poster { get; set; }
        public string body { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
    }

    /*
     * The RobloxGroupWallPoster class is meant to contain data for the poster of 
     * a group wall post.
    */
    public class RobloxGroupWallPoster
    {
        public RobloxGroupWallPoster(RobloxGroupWallPosterUser user, RobloxGroupRole role)
        {
            this.user = user;
            this.role = role;
        }

        public RobloxGroupWallPosterUser user { get; set; }
        public RobloxGroupRole role { get; set; }
    }

    /*
     * The RobloxGroupWallPosterUser class is meant to contain data for the user
     * of the poster of a group wall post.
    */
    public class RobloxGroupWallPosterUser
    {
        public RobloxGroupWallPosterUser(string buildersClubMembershipType, long userId, string username, string displayName)
        {
            this.buildersClubMembershipType = buildersClubMembershipType;
            this.userId = userId;
            this.username = username;
            this.displayName = displayName;
        }

        public string buildersClubMembershipType { get; set; }
        public long userId { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
    }

    /*
     * The RobloxBadge class is the class meant for containing Roblox badge information. 
    */
    public class RobloxBadge
    {
        public RobloxBadge(
            long id, 
            string name, 
            string description, 
            string displayName, 
            string displayDescription, 
            bool enabled, 
            long iconImageId, 
            long displayIconImageId, 
            DateTime created,
            DateTime updated,
            RobloxBadgeStatistics statistics
            )
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.displayName = displayName;
            this.displayDescription = displayDescription;
            this.enabled = enabled;
            this.iconImageId = iconImageId;
            this.displayIconImageId = displayIconImageId;
            this.created = created;
            this.updated = updated;
            this.statistics = statistics;
        }

        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string displayName { get; set; }
        public string displayDescription { get; set; }
        public bool enabled { get; set; }
        public long iconImageId { get; set; }
        public long displayIconImageId { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public RobloxBadgeStatistics statistics { get; set; }
    }

    public class RobloxBadgeStatistics
    {
        public RobloxBadgeStatistics(int pastDayAwardedCount, int awardedCount, int winRatePercentage)
        {
            this.pastDayAwardedCount = pastDayAwardedCount;
            this.awardedCount = awardedCount;
            this.winRatePercentage = winRatePercentage;
        }

        public int pastDayAwardedCount { get; set; }
        public int awardedCount { get; set; }
        public int winRatePercentage { get; set; }
    }
}
