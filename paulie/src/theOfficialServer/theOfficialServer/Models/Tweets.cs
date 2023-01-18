using System.Text.Json;

namespace theOfficialServer.Models
{
    public class Tweets
    {
        public string AvatarImage { get; set; }
        public string UserName { get; set; }
        public string UserHandle { get; set; }
        public string Tweet { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public string GIF { get; set; }
        public int ReTweetCount { get; set; }
        public int LikeCount { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Tweets>(this);

    }
}
