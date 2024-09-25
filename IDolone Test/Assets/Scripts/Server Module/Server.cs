using UnityEngine.Networking;

namespace Server_Module
{
    public sealed class Server
    {
        private readonly string _url;

        public Server(string url)
        {
            _url = url;
        }

        public UnityWebRequest Post(string bodyJson)
        {
            return UnityWebRequest.Post(_url, bodyJson, "application/json");
        }
    }
}