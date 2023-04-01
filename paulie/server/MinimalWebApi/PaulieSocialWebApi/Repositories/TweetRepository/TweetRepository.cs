using static System.Net.WebRequestMethods;

namespace PaulieSocialWebApi.Repositories.TweetRepository
{
    public class TweetRepository : ITweetRepository
    {
        private static List<Twitter> mockTweets = new List<Twitter>()
        {
           new Twitter()
           {
               TweetContent = "Just tried a new vegan restaurant and it was amazing! Who says plant-based food can't be delicious? 🌱👌 #vegan #foodie #yum",
               AuthorId = new AuthorId{ UserName = "Cool dude", UserImage = "https://images.unsplash.com/photo-1679572255334-08dd1c8cbdd7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1045&q=80"},
               MediaKey = new MediaKey{ Url = "https://media0.giphy.com/media/l41YusJpVvAAs2gNO/giphy.gif?cid=ecf05e47ebb9552fd7ea9fc9e12d6363ee61e151d3d0969e&rid=giphy.gif&ct=g"},
               RetweetCount = 10,
               HeartedCount = 25        
           },

           new Twitter()
           {
               TweetContent = "Can't believe it's already March! Time is flying by so fast ⏰⏳ #timemovesfast #timeflies #march",
               AuthorId = new AuthorId{ UserName = "janedoe", UserImage = "https://images.unsplash.com/photo-1679282561664-259aadb1fc97?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80"},
               //MediaKey = new MediaKey{ Image = "https://www.warrenphotographic.co.uk/photography/bigs/37049-Ginger-cat-sitting-in-cardboard-box-white-background.jpg"},
               RetweetCount = 5,
               HeartedCount = 15
           },

           new Twitter()
           {
               TweetContent = "Can't believe it's already Friday! This week flew by so fast. Time to relax and enjoy the weekend. #TGIF #weekendvibes",
               AuthorId = new AuthorId{ UserName = "sarahsmith", UserImage = "https://images.unsplash.com/photo-1679503624359-8a1841111961?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=688&q=80"},
               MediaKey = new MediaKey{ Url = "https://www.youtube.com/watch?v=C7eSobE3Ms4"},
               RetweetCount = 2,
               HeartedCount = 10
           },

           new Twitter()
           {
               TweetContent = "Just finished a challenging workout and feeling proud of myself 💪🏋️‍♀️ #fitnessmotivation #workout #proud",
               AuthorId = new AuthorId{ UserName = "Lucky Dragon", UserImage = "https://images.unsplash.com/photo-1679305289765-c899db4ce88a?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=735&q=80"},
               MediaKey = new MediaKey{ Url = "https://images.unsplash.com/photo-1519681393784-d120267933ba?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80"},
               RetweetCount = 77,
               HeartedCount = 109
           },

           new Twitter()
           {
               TweetContent = "Just tried a new restaurant and the food was amazing! If you're in the area, you have to check it out. #foodie #yum",
               AuthorId = new AuthorId{ UserName = "bookworm", UserImage = "https://images.unsplash.com/photo-1678884212100-d6bc7a5b831c?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=627&q=80"},
               MediaKey = new MediaKey{ Url = "https://media1.giphy.com/media/Vi0Ws3t4JSLOgdkaBq/giphy.gif?cid=ecf05e4758dfa88fbaf5e397f251ac4fd7b90b241cb2da6a&rid=giphy.gif&ct=g"},
               RetweetCount = 3,
               HeartedCount = 12
           },

           new Twitter()
           {
               TweetContent = "There's nothing better than a good book and a cozy blanket on a rainy day ☔️📖 #reading #rainydayvibes #cozy",
               AuthorId = new AuthorId{ UserName = "Bill Z", UserImage = "https://images.unsplash.com/photo-1679345793202-835054a858c3?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80"},
               MediaKey = new MediaKey{ Url = "https://www.youtube.com/watch?v=lOoue_yvSDs"},
               RetweetCount = 20,
               HeartedCount = 50
           },

           new Twitter()
           {
               TweetContent = "Sometimes all you need is a little bit of self-care to recharge 🔋💆‍♀️ #selfcare #mentalhealth #recharge",
               AuthorId = new AuthorId{ UserName = "companyx", UserImage = "https://images.unsplash.com/photo-1679560271870-e8f4eb3314da?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1214&q=80"},
               MediaKey = new MediaKey{ Url = "https://images.unsplash.com/photo-1679491990168-cb392af584c7?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=687&q=80"},
               RetweetCount = 40,
               HeartedCount = 30
           }
        };

        //Mock Service Methods
        public IEnumerable<Twitter> GetAllTweets()
        {
            return mockTweets;
        }
        public IEnumerable<Twitter> GetTweetsByContent(string searchTerm)
        {
            List<Twitter> tweets = new List<Twitter>();

            foreach(Twitter twitter in mockTweets) 
            { 
                if(twitter.TweetContent.Contains(searchTerm))
                {
                    tweets.Add(twitter);
                }
            }
            return tweets;
        }

        public IEnumerable<Twitter> GetTweetsByUsername(string username)
        {
            List<Twitter> tweets = new List<Twitter>();

            foreach (Twitter twitter in mockTweets)
            { 
                var lowerCase= twitter.AuthorId.UserName.ToLower();

                if (lowerCase.Equals(username.ToLower()))
                {
                    tweets.Add(twitter);
                }
            }
            return tweets;
        }
        public Twitter GetRandomTweet(int id)
        {
            throw new NotImplementedException();
        }     
    }
}
