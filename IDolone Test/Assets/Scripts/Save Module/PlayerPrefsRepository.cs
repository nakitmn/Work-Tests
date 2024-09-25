using UnityEngine;

namespace Save_Module
{
    public sealed class PlayerPrefsRepository : ISaveRepository
    {
        public void Del(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public string Get(string key)
        {
            return PlayerPrefs.GetString(key);
        }

        public bool Has(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public void Set(string key, string data)
        {
            PlayerPrefs.SetString(key, data);
        }
    }
}