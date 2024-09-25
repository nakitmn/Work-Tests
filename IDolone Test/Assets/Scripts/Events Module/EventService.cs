using Newtonsoft.Json;
using Save_Module;
using Server_Module;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Events_Module
{
    public sealed class EventService : MonoBehaviour
    {
        private const string CACHED_EVENTS_KEY = "cached_events";

        [SerializeField] private string _serverUrl;
        [SerializeField] private float _cooldownBeforeSend;

        private Queue<ServerEvent> _events;
        private Coroutine _sendEventsAfterCooldownCoroutine;
        private Coroutine _uploadEventsCoroutine;
        private Server _server;
        private ISaveRepository _repository;

        private void Awake()
        {
            _server = new(_serverUrl);
            _repository = new PlayerPrefsRepository();
        }

        private void Start()
        {
            LoadCachedEvents();
            SendEvents();
        }

        public void TrackEvent(string type, string data)
        {
            Debug.Log($"Event <color=yellow>{type}</color>:[{data}]");

            ServerEvent serverEvent = new(type, data);
            _events.Enqueue(serverEvent);

            CacheEvents();

            if (_sendEventsAfterCooldownCoroutine == null)
            {
                _sendEventsAfterCooldownCoroutine = StartCoroutine(SendEventsAfterCooldownRoutine());
            }
        }

        private void SendEvents()
        {
            if (_events.Count == 0 || _uploadEventsCoroutine != null)
            {
                return;
            }

            _uploadEventsCoroutine = StartCoroutine(UploadEventsRoutine());
        }

        private void LoadCachedEvents()
        {
            if (_repository.Has(CACHED_EVENTS_KEY) == false)
            {
                _events = new();
                return;
            }

            string eventsJson = _repository.Get(CACHED_EVENTS_KEY);
            _events = JsonConvert.DeserializeObject<Queue<ServerEvent>>(eventsJson);
        }

        private void CacheEvents()
        {
            if (_events.Count == 0)
            {
                _repository.Del(CACHED_EVENTS_KEY);
                return;
            }

            string eventsJson = JsonConvert.SerializeObject(_events, Formatting.Indented);
            _repository.Set(CACHED_EVENTS_KEY, eventsJson);
        }

        private IEnumerator UploadEventsRoutine()
        {
            string eventsJson = _repository.Get(CACHED_EVENTS_KEY);
            int eventsCount = _events.Count;

            Debug.Log("Sending events...");

            using (UnityWebRequest request = _server.Post(eventsJson))
            {
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(request.error);
                }
                else
                {
                    Debug.Log($"<color=green>Events delivered:</color>\n{eventsJson}");

                    for (int i = 0; i < eventsCount; i++)
                    {
                        _events.Dequeue();
                    }

                    CacheEvents();
                }
            }

            _uploadEventsCoroutine = null;
        }

        private IEnumerator SendEventsAfterCooldownRoutine()
        {
            yield return new WaitForSeconds(_cooldownBeforeSend);
            SendEvents();
            _sendEventsAfterCooldownCoroutine = null;
        }
    }
}
