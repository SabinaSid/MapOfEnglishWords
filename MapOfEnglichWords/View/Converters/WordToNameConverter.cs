using System;
using System.Globalization;
using System.Windows.Data;
using MapOfEnglishWords.Model;

namespace MapOfEnglishWords.View.Converters
{
    public class WordToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Word w) 
                return w.Name;

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
