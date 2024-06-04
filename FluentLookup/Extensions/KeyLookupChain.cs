using System.Collections.Generic;

namespace FluentLookup.Extensions
{
    public class KeyLookupChain<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> _dictionary;
        private readonly List<TKey> _keys;

        public KeyLookupChain(IDictionary<TKey, TValue> dictionary)
        {
            _dictionary = dictionary;
            _keys = new List<TKey>();
        }

        public KeyLookupChain<TKey, TValue> ThenKey(TKey key)
        {
            _keys.Add(key);
            return this;
        }
        
        public bool TryGetValue(out TValue value)
        {
            value = default;
            foreach (var key in _keys)
            {
                if (_dictionary.TryGetValue(key, out value))
                {
                    return true;
                }
            }

            return false;
        }

        public TValue GetValueOrDefault(TValue defaultValue)
        {
            return TryGetValue(out var value) ? value : defaultValue;
        }
    }
}