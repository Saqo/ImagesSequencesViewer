using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using WpfApplication1.Commands;
using WpfApplication1.Models;

namespace WpfApplication1.ViewModels
{
    enum AppStates { WaitDirectorySelection, DisplayImages }
    enum TemplateTypesEnum { Common, Advanced }
    class ImageViewModel : Notifier
    {
        private AppStates _state { get; set; }
        private bool _isPlaying;
        private int _counter, _imagecounter, _interval, _directoriesCount;
        private TemplateTypesEnum _type;
        private ICommand _startCommand;
        private Timer _timer;
        private string _rootDirectory;

        public int DirectoriesCount
        {
            get { return _directoriesCount; }
            set { _directoriesCount = value; OnPropertyChanged("DirectoriesCount"); }
        }
        public TemplateTypesEnum SelectedType
        {
            get { return _type; }
            set { _type = value; OnPropertyChanged("SelectedType"); }
        }
        public IEnumerable<TemplateTypesEnum> TemplateTypes
        {
            get { return Enum.GetValues(typeof(TemplateTypesEnum)).Cast<TemplateTypesEnum>(); }
        }

        List<string> Extensions = new List<string> { ".jpg", ".bmp", ".png" };
        public string SelectedDirectory { get; set; }
        public bool IsPlaying
        {
            get { return _isPlaying; }
            set { _isPlaying = value; OnPropertyChanged("IsPlaying"); }
        }
        public ICommand StartCommand
        {
            get
            {
                return _startCommand ?? (_startCommand = new ClickCommand(x =>
                {
                    if (_state == AppStates.WaitDirectorySelection)
                    {
                        FolderBrowserDialog dialog = new FolderBrowserDialog(); dialog.ShowDialog();
                        if (!string.IsNullOrEmpty(dialog.SelectedPath))
                            if (DirectoriesUtils.DirectoriesWithFilesByExtensionsCount(dialog.SelectedPath, Extensions) > 0)
                            { GetImages(dialog.SelectedPath); InitTimer(); _state = AppStates.DisplayImages; IsPlaying = true; }
                            else { MessageBox.Show("Folder does not contain subdirectories!"); }
                    }
                    else
                    { _timer.Enabled = !_timer.Enabled; IsPlaying = _timer.Enabled; }
                }));
            }
        }
        public ObservableCollection<ImageModel> Images { get; set; }
        public int Interval
        {
            get { return _interval; }
            set { _interval = value; _timer.Interval = value; OnPropertyChanged("Interval"); }
        }

        public ImageViewModel()
        {
            Images = new ObservableCollection<ImageModel>();
            IsPlaying = false;
            _timer = new Timer();
            Interval = 400;
            _counter = 0;
            SelectedType = TemplateTypesEnum.Common;
            _state = AppStates.WaitDirectorySelection;
        }


        public void GetImages(string selectedPath)
        {
            _rootDirectory = selectedPath;
            Images.Clear();
            DirectoriesCount = DirectoriesUtils.DirectoriesWithFilesByExtensionsCount(_rootDirectory, Extensions);
            _imagecounter = FilesUtils.GetFilesCount(DirectoriesFactory.Instance.GetDirectory(0, _rootDirectory, Extensions), Extensions);
            for (var i = 0; i < DirectoriesCount; i++)
            {
                Images.Add(ImagesFactory.Instance.GetImageModel(i, DirectoriesFactory.Instance.GetDirectory(i, selectedPath, Extensions)));
                if (i > 0 && _imagecounter != FilesUtils.GetFilesCount(DirectoriesFactory.Instance.GetDirectory(i, _rootDirectory, Extensions), Extensions))
                {
                    throw new Exception("Images count in folders not equal");
                }
            }
        }

        private void InitTimer()
        {
            _timer.Tick += timer_Tick;
            _timer.Interval = Interval;
            _timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < DirectoriesCount; i++)
            {
                var path = FilesUtils.GetFilePath(DirectoriesFactory.Instance.GetDirectory(i, _rootDirectory, Extensions), Extensions, _counter);
                Images[i].Title = FilesUtils.GetFileName(path);
                Images[i].Path = new Uri(path, UriKind.Relative);
            }
            if (++_counter == _imagecounter)
                _counter = 0;
        }
    }
}
