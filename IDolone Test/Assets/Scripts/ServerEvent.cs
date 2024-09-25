using System;
using System.Collections;
using UnityEngine;

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