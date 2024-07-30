using System;
using UnityEngine;

namespace Core
{
    public sealed class AnimatorDispatcher : MonoBehaviour
    {
        public event Action<string> EventRaised; 

        public void SendAnimationEvent(string key)
        {
            EventRaised?.Invoke(key);
        }
    }
}