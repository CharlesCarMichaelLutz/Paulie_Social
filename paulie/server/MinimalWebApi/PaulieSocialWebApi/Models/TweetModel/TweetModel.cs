
using Newtonsoft.Json;
using PaulieSocialWebApi.Models.UserIdModel;

namespace PaulieSocialWebApi.Models.TweetModel
{
    [Serializable]
    public class TweetModel
    {
        public TweetData[] Data { get; set; }
        public includes includes { get; set; } 
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
        public media[] media { get; set; }
    }

    public class media
    {
        public string type { get; set; }
        public string media_key { get; set; }
    }
}

