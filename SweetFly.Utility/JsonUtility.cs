using Newtonsoft.Json;

namespace SweetFly.Utility
{
    public static class JsonUtility
    {
        public static string Serialize<T>(T model)
        {
            return JsonConvert.SerializeObject(model);
        }

        public static T Deserialize<T>(string src)
        {
            return JsonConvert.DeserializeObject<T>(src);
        }
    }
}
