using System.Collections.Specialized;

namespace PaulieSocialWebApi.Extensions
{
    public static class NameValueCollectionExtensions
    {
        public static void AddStandardTwitterQueryStrings(this NameValueCollection queryStrings)
        {
            queryStrings["tweet.fields"] = "attachments,author_id,public_metrics,source";
            queryStrings["expansions"] = "attachments.media_keys,author_id";
            queryStrings["media.fields"] = "url,variants,media_key,type";
            queryStrings["user.fields"] = "profile_image_url";
            queryStrings["max_results"] = "15";
        }
    }
}
