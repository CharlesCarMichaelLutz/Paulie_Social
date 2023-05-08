
using Newtonsoft.Json;
using PaulieSocialWebApi.Models.UserIdModel;

namespace PaulieSocialWebApi.Models.TweetModel
{
    [Serializable]
    public class TweetModel
    {
        public TweetData[] Data { get; set; }
    }
    public class TweetData
    {
        public public_metrics public_metrics { get; set; }
        public string text { get; set; }
        public string id { get; set; }
        public string author_id { get; set; }
        //public attachments attachments { get; set; }
    }

    public class public_metrics
    {
        public int retweet_count { get; set; }
        public int like_count { get; set; }
    }

    //public class attachments
    //{
    //    public media_keys[] media_keys { get; set; }
    //}

    //public class media_keys 
    //{
    //    public string video { get; set; }
    //    public string audio { get; set; }
    //    public string video_id { get; set;}
    //}
}

