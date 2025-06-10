using System.Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WaterCarrierManagementSystem.Desktop.Common.Converters;

public class ColorFromTransprent : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            bool isPreviewCollapsed = values[0] is Visibility.Collapsed;

            if (isPreviewCollapsed)
            {
                return values[1];
            }
            
            return Color.Transparent;
        }
        catch 
        {
            throw new Exception("Color convertation error");
        }
        
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
