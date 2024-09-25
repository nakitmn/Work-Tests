using System.Collections;
using UnityEngine;

namespace Events_Module
{
    public sealed class DebugEventsRaiser : MonoBehaviour
    {
        [SerializeField] private EventService _eventService;
        [SerializeField] private Vector2 _sendEventCooldown = new(0.25f, 5f);

        private readonly string[] _eventTypes = new[]
        {
            "levelStart",
            "levelFinish",
            "damaged",
            "healed",
            "died"
        };

        private readonly string[] _eventDatas = new[]
        {
            "level 1",
            "20 HP",
            "52",
            "lvl 228",
            "win"
        };

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(_sendEventCooldown.x, _sendEventCooldown.y));

                string type = _eventTypes[Random.Range(0, _eventTypes.Length)];
                string data = _eventDatas[Random.Range(0, _eventDatas.Length)];
                _eventService.TrackEvent(type, data);
            }
        }

    }
}