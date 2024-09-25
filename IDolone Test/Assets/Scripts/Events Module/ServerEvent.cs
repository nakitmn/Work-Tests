using System;

namespace Events_Module
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