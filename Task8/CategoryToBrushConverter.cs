using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Task8
{
    public class CategoryToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Category category)
            {
                return category == Category.Food
                    ? new SolidColorBrush(Color.FromRgb(220, 255, 220)) 
                    : new SolidColorBrush(Color.FromRgb(220, 240, 255)); 
            }
            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
