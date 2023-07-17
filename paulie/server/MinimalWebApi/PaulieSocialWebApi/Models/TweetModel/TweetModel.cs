
using Newtonsoft.Json;
using PaulieSocialWebApi.Models.UserIdModel;

namespace PaulieSocialWebApi.Models.TweetModel
{
    [Serializable]
    public class TweetModel
    {
        public TweetData[] Data { get; set; }
        public includes Includes { get; set; }
    }
    public class TweetData
    {
        public string author_id { get; set; }
        public string text { get; set; }
        public string id { get; set; }
        public public_metrics public_metrics { get; set; }
        public attachments attachments { get; set; }
    }
    public class public_metrics
    {
        public int retweet_count { get; set; }
        public int like_count { get; set; }
    }
    public class attachments
    {
        public string[] media_keys { get; set; }
    }
    public class includes
    {
        public media[] Media { get; set; }
        public users[] Users { get; set; }
    }
    public class media
    {
        public string Type { get; set; }
        public string Media_key { get; set; }
        public string url { get; set; }
        public variants[] Variants { get; set; }
    }

    public class variants
    {
        public string url { get; set; }
    }
    public class users
    {
        public string username { get; set; }
        public string profile_image_url { get; set; }
    }

    //public class TweetModel
    //{
    //    public TweetData[] Data { get; set; }
    //    public Includes Includes { get; set; }
    //}

    //public class TweetData
    //{
    //    public string author_id { get; set; }
    //    public string text { get; set; }
    //    public string id { get; set; }
    //    public PublicMetrics public_metrics { get; set; }
    //    public Attachments attachments { get; set; }
    //}

    //public class PublicMetrics
    //{
    //    public int retweet_count { get; set; }
    //    public int like_count { get; set; }
    //}

    //public class Attachments
    //{
    //    public Media[] media_keys { get; set; }
    //}

    //public class Includes
    //{
    //    public Media[] Media { get; set; }
    //    public User[] Users { get; set; }
    //}

    //public class Media
    //{
    //    public string Type { get; set; }
    //    public string Media_key { get; set; }
    //    public string url { get; set; }
    //    public Variants[] Variants { get; set; }
    //}

    //public class Variants
    //{
    //    public string url { get; set; }
    //}

    //public class User
    //{
    //    public string username { get; set; }
    //    public string profile_image_url { get; set; }
    //}
}

