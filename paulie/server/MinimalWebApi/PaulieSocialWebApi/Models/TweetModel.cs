namespace PaulieSocialWebApi.Models
{
    [Serializable]
    public class TweetModel
    {
        public TweetData[] Data { get; set; }
        public Includes Includes { get; set; }
    }
    public class TweetData
    {
        public string author_id { get; set; }
        public string text { get; set; }
        public string id { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public Attachments attachments { get; set; }
    }
    public class PublicMetrics
    {
        public int retweet_count { get; set; }
        public int like_count { get; set; }
    }
    public class Attachments
    {
        public string[] media_keys { get; set; }
    }
    public class Includes
    {
        public Media[] Media { get; set; }
        public Users[] Users { get; set; }
    }
    public class Media
    {
        public string Type { get; set; }
        public string Media_key { get; set; }
        public string url { get; set; }
        public Variants[] Variants { get; set; }
    }

    public class Variants
    {
        public string url { get; set; }
    }
    public class Users
    {
        public string username { get; set; }
        public string profile_image_url { get; set; }
        public string id { get; set; }
    }
}

