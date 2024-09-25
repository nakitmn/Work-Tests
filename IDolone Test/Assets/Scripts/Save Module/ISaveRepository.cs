namespace Save_Module
{
    public interface ISaveRepository
    {
        public void Set(string key, string data);
        public string Get(string key);
        public bool Has(string key);
        public void Del(string key);
    }
}