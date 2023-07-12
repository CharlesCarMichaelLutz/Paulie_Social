namespace PaulieSocialWebApi.Models.UserIdModel
{
    [Serializable]
    public class UserIdModel
    {
        public Data data { get; set; }
    }
    public class Data
    {
        public string id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
    }
}
