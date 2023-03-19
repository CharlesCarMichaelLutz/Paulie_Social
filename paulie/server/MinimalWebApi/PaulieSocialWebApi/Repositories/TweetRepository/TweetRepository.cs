namespace PaulieSocialWebApi.Repositories.TweetRepository
{
    public class TweetRepository : ITweetRepository
    {
        private static List<Twitter> _tweets = new List<Twitter>()
        {
            // Twitter objects will be entered here
        };

        public List<Twitter> GetTweets()
        {
            return _tweets;
        }
    }
}
