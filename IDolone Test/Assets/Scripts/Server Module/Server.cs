using System.Text;
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
            var request = UnityWebRequest.Post(_url, "POST");
            request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyJson));
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            return request;
        }
    }
}