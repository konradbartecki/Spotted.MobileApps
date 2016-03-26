using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Visibility;

namespace Spotted.UWP.Converters
{
    public class MvxVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var mvxVisibility = (MvxVisibility) value;
            return 
                mvxVisibility == MvxVisibility.Visible 
                ? Visibility.Visible 
                : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
