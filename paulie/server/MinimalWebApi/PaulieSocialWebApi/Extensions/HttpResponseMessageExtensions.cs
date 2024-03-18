using Newtonsoft.Json;
using PaulieSocialWebApi.Models;

namespace PaulieSocialWebApi.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<TweetModel> DeserializeOrThrow(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<TweetModel>(json);

            if (data is null)
            {
                throw new NullReferenceException();
            }

            return data;
        }
    };
}
