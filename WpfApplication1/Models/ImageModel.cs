using System;

namespace WpfApplication1.Models
{
    public class ImageModel : Notifier
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged("Title"); }
        }
        private Uri _path;
        public Uri Path
        {
            get { return _path; }
            set { _path = value; OnPropertyChanged("Path"); }
        }

        private string _directory;
        public string Directory
        {
            get { return _directory; }
            set { _directory = value; OnPropertyChanged("Directory"); }
        }
    }
}
