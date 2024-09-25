using System;

namespace Assets.Scripts
{
    [Serializable]
    public readonly struct ServerEvent
    {
        public readonly string Type;
        public readonly string Data;

        public ServerEvent(string type, string data)
        {
            Type = type;
            Data = data;
        }
    }
}