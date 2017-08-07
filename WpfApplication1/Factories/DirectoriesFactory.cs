using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfApplication1
{
    public sealed class DirectoriesFactory
    {
        private static Lazy<DirectoriesFactory> _instance = new Lazy<DirectoriesFactory>(() => new DirectoriesFactory());

        private Dictionary<int, string> _dict;
        private DirectoriesFactory() { _dict = new Dictionary<int, string>(); }
        public static DirectoriesFactory Instance
        {
            get { return _instance.Value; }
        }

        public string GetDirectory(int key, string root, IEnumerable<string> extensions)
        {
            if (!_dict.ContainsKey(key))
                FillDict(root, extensions);
            return _dict[key];
        }

        private void FillDict(string root, IEnumerable<string> extensions)
        {
            _dict.Clear();
            var dicts = DirectoriesUtils.DirectoriesWithFilesByExtensions(root, extensions).ToArray();
            for (int i = 0; i < dicts.Length; i++)
                _dict.Add(i, dicts[i]);
        }


    }
}
