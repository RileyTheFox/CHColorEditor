using System;
using System.Collections.Generic;
using System.Text;

namespace SideyUtils.Data
{
    /// <summary>
    /// Represent a case-insensitive lookup table
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CaseInsensitiveLookupTable<T>
    {
        private struct TableItem
        {
            public T Value;
            public string OriginalKey;

            public TableItem(string key, T value)
            {
                OriginalKey = key;
                Value = value;
            }
        }

        private TableItem _default;

        private readonly Dictionary<string, TableItem> _items;

        /// <summary>
        /// Registers an item into this LookupTable.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public CaseInsensitiveLookupTable<T> Register(string key, T value)
        {
            _items.Add(key.ToLowerInvariant(), new TableItem(key, value));

            return this;
        }

        /// <summary>
        /// Looks up the given key case-insensitively. Ex. "Event" will be looked up as "event".
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Lookup(string key)
        {
            if (!_items.TryGetValue(key.ToLowerInvariant(), out TableItem result))
            {
                return _default.Value;
            }

            return result.Value;
        }

        /// <summary>
        /// Will try to get the value for the key if it exists, if it doesn't exist it will return false.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>true if the value exists.</returns>
        public bool TryLookupValue(string key, out T value)
        {
            if (!_items.TryGetValue(key.ToLowerInvariant(), out TableItem result))
            {
                value = result.Value;

                return false;
            }

            value = default;
            return true;
        }

        /// <summary>
        /// Determines if this lookup table contains the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return _items.ContainsKey(key.ToLowerInvariant());
        }

        /// <summary>
        /// Looks up the original key for the search key. Ex. Searching "event" will return "Event" as "Event" was the registering key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string LookupOriginalKey(string key)
        {
            if (!_items.TryGetValue(key.ToLowerInvariant(), out TableItem result))
            {
                return _default.OriginalKey;
            }

            return result.OriginalKey;
        }

        /// <summary>
        /// Creates an empty CaseInsensitiveLookupTable, with the default lookup value being as empty as it can get.
        /// </summary>
        public CaseInsensitiveLookupTable() : this(string.Empty, default)
        {
        }

        /// <summary>
        /// Creates an empty CaseInsensitiveLookupTable with the default value set to the given key and value.
        /// </summary>
        /// <param name="defaultKey"></param>
        /// <param name="defaultValue"></param>
        public CaseInsensitiveLookupTable(string defaultKey, T defaultValue)
        {
            _default = new TableItem(defaultKey, defaultValue);
            _items = new Dictionary<string, TableItem>();
        }

        /// <summary>
        /// Creates an empty CaseInsensitiveLookupTable with the default value set to the given value.
        /// </summary>
        /// <param name="defaultValue"></param>
        public CaseInsensitiveLookupTable(T defaultValue)
        {
            _default = new TableItem(string.Empty, defaultValue);
            _items = new Dictionary<string, TableItem>();
        }

        /// <summary>
        /// Sets the default lookup value of this 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetDefaultValue(string key, T value)
        {
            _default = new TableItem(key, value);
        }
    }
}
