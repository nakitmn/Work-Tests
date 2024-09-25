using Assets.Scripts;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public sealed class EventService : MonoBehaviour
{
    private const string CACHED_EVENTS_KEY = "cached_events";

    [SerializeField] private string _serverUrl;
    [SerializeField] private float _cooldownBeforeSend;

    private Queue<ServerEvent> _events;
    private Server _server;
    private ISaveRepository _repository;
    private Coroutine _sendEventsCoroutine;

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
        ServerEvent serverEvent = new(type, data);
        _events.Enqueue(serverEvent);
        CacheEvents();

        Debug.Log($"Event <color=yellow>{type}</color>:[{data}]");

        if (_sendEventsCoroutine == null)
        {
            _sendEventsCoroutine = StartCoroutine(SendEventsRoutine());
        }
    }

    public void SendEvents()
    {
        if (_events.Count == 0)
        {
            return;
        }

        StartCoroutine(UploadEventsRoutine());
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

        _repository.Set(CACHED_EVENTS_KEY, GetEventsAsJson());
    }

    private string GetEventsAsJson()
    {
        return JsonConvert.SerializeObject(_events, Formatting.Indented);
    }

    private IEnumerator UploadEventsRoutine()
    {
        string eventsJson = GetEventsAsJson();
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
    }

    private IEnumerator SendEventsRoutine()
    {
        yield return new WaitForSeconds(_cooldownBeforeSend);
        SendEvents();
        _sendEventsCoroutine = null;
    }
}
