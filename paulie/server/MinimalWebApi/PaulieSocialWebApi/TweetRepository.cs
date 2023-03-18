namespace PaulieSocialWebApi
{
    public class TweetRepository
    {
        private static List<Twitter> Tweets = new List<Twitter>()
       {
           new Twitter()
           {
               AuthorId = "johndoe",
               TweetContent = "Just tried a new vegan restaurant and it was amazing! Who says plant-based food can't be delicious? 🌱👌 #vegan #foodie #yum",
               MediaKey = "https://media.giphy.com/media/dK2BEvMcURWvW/giphy.gif",
               RetweetCount = 10,
               HeartedCount = 25
           },

           new Twitter()
           {
               AuthorId = "janedoe",
               TweetContent = "Can't believe it's already March! Time is flying by so fast ⏰⏳ #timemovesfast #timeflies #march",
               MediaKey = "https://www.warrenphotographic.co.uk/photography/bigs/37049-Ginger-cat-sitting-in-cardboard-box-white-background.jpg",
               RetweetCount = 5,
               HeartedCount = 15
           },

            new Twitter()
           {
               AuthorId = "sarahsmith",
               TweetContent = "Can't believe it's already Friday! This week flew by so fast. Time to relax and enjoy the weekend. #TGIF #weekendvibes",
               MediaKey = "https://www.youtube.com/watch?v=ahN1JFV7Ejg",
               RetweetCount = 2,
               HeartedCount = 10
           },

             new Twitter()
           {
               AuthorId = "Lucky Dragon",
               TweetContent = "Just finished a challenging workout and feeling proud of myself 💪🏋️‍♀️ #fitnessmotivation #workout #proud",
               MediaKey = "https://images.unsplash.com/photo-1519681393784-d120267933ba?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
               RetweetCount = 77,
               HeartedCount = 109
           },

              new Twitter()
           {
               AuthorId = "bookworm",
               TweetContent = "Just tried a new restaurant and the food was amazing! If you're in the area, you have to check it out. #foodie #yum",
               MediaKey = "https://media.giphy.com/media/Nx0rz3jtxtEre/giphy.gif",
               RetweetCount = 3,
               HeartedCount = 12
           },

               new Twitter()
           {
               AuthorId = "Bill Z",
               TweetContent = "There's nothing better than a good book and a cozy blanket on a rainy day ☔️📖 #reading #rainydayvibes #cozy",
               MediaKey = "https://www.youtube.com/watch?v=8dFnJzxsqsY",
               RetweetCount = 20,
               HeartedCount = 50
           },
                new Twitter()
           {
               AuthorId = "companyx",
               TweetContent = "Sometimes all you need is a little bit of self-care to recharge 🔋💆‍♀️ #selfcare #mentalhealth #recharge",
               MediaKey = "https://images.unsplash.com/photo-1560252823-8a9970e1f9cc?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
               RetweetCount = 40,
               HeartedCount = 30
           }
       };

       //Create CRUD Methods here
    }
}
