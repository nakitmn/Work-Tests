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

    private Queue<ServerEvent> _events = new();
    private Server _server;
    private Coroutine _sendEventsCoroutine;

    private void Start()
    {
        _server = new(_serverUrl);
        SendCachedEvents();
    }

    public void TrackEvent(string type, string data)
    {
        ServerEvent serverEvent = new(type, data);
        _events.Enqueue(serverEvent);

        Debug.Log($"Event {type}:[{data}]");

        PlayerPrefs.SetString(CACHED_EVENTS_KEY, GetEventsAsJson());

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

        StartCoroutine(Upload());
    }

    private IEnumerator Upload()
    {
        string eventsJson = GetEventsAsJson();
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
                Debug.Log($"Events delivered:\n{eventsJson}");
                _events.Clear();
            }
        }
    }

    private void SendCachedEvents()
    {
        if (PlayerPrefs.HasKey(CACHED_EVENTS_KEY))
        {
            string eventsJson = PlayerPrefs.GetString(CACHED_EVENTS_KEY);
            _events = JsonConvert.DeserializeObject<Queue<ServerEvent>>(eventsJson);
            PlayerPrefs.DeleteKey(CACHED_EVENTS_KEY);
            SendEvents();
        }
    }

    private IEnumerator SendEventsRoutine()
    {
        yield return new WaitForSeconds(_cooldownBeforeSend);
        SendEvents();
        _sendEventsCoroutine = null;
    }

    private string GetEventsAsJson()
    {
        return JsonConvert.SerializeObject(_events, Formatting.Indented);
    }
}
