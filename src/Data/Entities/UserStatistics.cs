namespace Birdie.Core.Data.Entities
{
    public class UserStatistics
    {
        public long Id { get; set; }
        public int FollowersCount { get; set; }
        public int FriendsCount { get; set; }
        public int ListedCount { get; set; }
        public int FavouritesCount { get; set; }
        public int StatusCount { get; set; }
        public int MediaCount { get; set; }
        
        public long UserId { get; set; }
        public User User { get; set; }
    }
}