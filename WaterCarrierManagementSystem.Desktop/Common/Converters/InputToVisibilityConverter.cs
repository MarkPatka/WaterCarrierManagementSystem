using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WaterCarrierManagementSystem.Desktop.Common.Converters;

public class InputToVisibilityConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            bool hasText = !string.IsNullOrEmpty($"{values[0]}");

            bool hasFocus = (bool)values[1];

            if (hasText || hasFocus)
            {
                return Visibility.Collapsed;
            }
            
            return Visibility.Visible;
        }
        catch 
        {
            throw new Exception("Visibility convertation error");
        }
        
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
