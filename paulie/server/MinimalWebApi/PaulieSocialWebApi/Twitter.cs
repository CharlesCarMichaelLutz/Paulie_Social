
namespace PaulieSocialWebApi
{
    public class Twitter
    {
        public string TweetContent { get; set; }
        public AuthorId AuthorId { get; set; }
        public MediaKey? MediaKey { get; set; }
        public int RetweetCount { get; set; }
        public int HeartedCount { get; set; }
    }
    public class AuthorId
    {
        public string  UserName { get; set; }
        public string UserImage { get; set; }
    }
    public class MediaKey
    {
        public string? Url { get; set; }
    }
}
