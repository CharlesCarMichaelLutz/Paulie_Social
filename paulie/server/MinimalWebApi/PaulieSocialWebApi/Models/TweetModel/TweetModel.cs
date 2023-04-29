
using Newtonsoft.Json;
using PaulieSocialWebApi.Models.UserIdModel;

namespace PaulieSocialWebApi.Models.TweetModel
{
    [Serializable]
    public class TweetModel
    {
        public data[] data { get; set; }
    }
    public class data
    {
        //public public_metrics[] public_metrics { get; set; }
        public string text { get; set; }
        public string id { get; set; }
        //public string author_id { get; set; }
    }

    //public class public_metrics
    //{
    //    public int retweet_count { get; set; }
    //    public int like_count { get; set; }
    //}
}

