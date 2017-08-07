using System;
using System.IO;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApplication1.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var str = Path.GetFileNameWithoutExtension(value.ToString()).ToUpper();
                switch (str)
                {
                    case "YELLOW": return new SolidColorBrush(Colors.Yellow);
                    case "GREEN": return new SolidColorBrush(Colors.Green);
                    case "RED": return new SolidColorBrush(Colors.Red);
                    default: return new SolidColorBrush(Colors.Black);
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
