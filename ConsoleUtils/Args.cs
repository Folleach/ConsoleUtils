using System;
using System.Collections;
using System.Collections.Generic;

namespace Folleach.ConsoleUtils
{
    public class Args : IEnumerable<KeyValuePair<string, string>>
    {
        private Dictionary<string, string> values = new Dictionary<string, string>();

        public Args(string[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                var key = args[i].Trim();
                if (!key.StartsWith("-", StringComparison.Ordinal))
                    continue;
                if (HasValue(args, i + 1))
                    AddWithValue(ParseNames(key), args[++i]);
                else
                    Add(ParseNames(key));
            }
        }

        public bool Contains(string name)
        {
            return values.ContainsKey(name);
        }

        public string GetString(string name)
        {
            return values.TryGetValue(name, out var value) ? value : null;
        }

        public bool TryGetString(string name, out string value)
        {
            return values.TryGetValue(name, out value);
        }

        private void Add(string[] names)
        {
            foreach (var name in names)
            {
                if (values.TryGetValue(name, out var value) && value != null)
                    continue;
                if (string.IsNullOrWhiteSpace(name))
                    continue;
                values[name] = null;
            }
        }

        private void AddWithValue(string[] names, string value)
        {
            Add(names);
            var key = names[names.Length - 1];
            values[key] = value;
        }

        private bool HasValue(string[] args, int index)
        {
            if (index >= args.Length)
                return false;
            return !args[index].StartsWith("-", StringComparison.Ordinal);
        }

        private string[] ParseNames(string key)
        {
            if (IsLongName(key))
                return new[] { key.Remove(0, 2) };
            var names = new string[key.Length - 1];
            for (var i = 1; i < key.Length; i++)
                names[i - 1] = key[i].ToString();
            return names;
        }

        private bool IsLongName(string name)
        {
            return name.StartsWith("--", StringComparison.Ordinal);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
