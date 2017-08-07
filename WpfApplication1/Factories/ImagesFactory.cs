using System;
using System.Collections.Generic;
using WpfApplication1.Models;

namespace WpfApplication1
{
    public sealed class ImagesFactory
    {
        private Dictionary<int, ImageModel> _dict;
        private static Lazy<ImagesFactory> _instance = new Lazy<ImagesFactory>(() => new ImagesFactory());

        public static ImagesFactory Instance
        {
            get { return _instance.Value; }
        }

        private ImagesFactory()
        {
            _dict = new Dictionary<int, ImageModel>();
        }
        public ImageModel GetImageModel(int key, string directory)
        {
            if (!_dict.ContainsKey(key))
                _dict.Add(key, new ImageModel { Directory = directory });
            return _dict[key];
        }

    }
}
