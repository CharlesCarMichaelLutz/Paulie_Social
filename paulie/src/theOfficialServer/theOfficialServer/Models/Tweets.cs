using Newtonsoft.Json;
using System.Text.Json;

namespace theOfficialServer.Models
{
    [Serializable]
    public class Tweets
    {
        //tweet fields & expansions
        //public string AvatarImage { get; set; }
        //author_id
        [JsonProperty("id")]
        public string UserName { get; set; }
        //public string UserHandle { get; set; }
        [JsonProperty("text")]
        public string Tweet { get; set; }
        //public string Image { get; set; }
        ////expansions=attachments.media_keys
        //public string Video { get; set; }
        //public string GIF { get; set; }
        ////public_metrics
        //public int ReTweetCount { get; set; }
        ////public_metrics
        //public int LikeCount { get; set; }

        //public override string ToString() => JsonSerializer.Serialize<Tweets>(this);
    }
}
