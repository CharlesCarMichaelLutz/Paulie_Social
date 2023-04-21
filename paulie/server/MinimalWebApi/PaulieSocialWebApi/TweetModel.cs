
using Newtonsoft.Json;

namespace PaulieSocialWebApi
{
    //Twitter Api Model
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

    //Mock Tweet Model

    //public class TweetModel
    //{
    //    public string TweetContent { get; set; }
    //    public AuthorId AuthorId { get; set; }
    //    public MediaKey? MediaKey { get; set; }
    //    public int RetweetCount { get; set; }
    //    public int HeartedCount { get; set; 
    //}
    //public class AuthorId
    //{
    //    public string UserName { get; set; }
    //    public string UserImage { get; set; }
    //}
    //public class MediaKey
    //{
    //    public string? Url { get; set; }
    //}
}

