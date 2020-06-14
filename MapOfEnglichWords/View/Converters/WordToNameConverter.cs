using System;
using System.Globalization;
using System.Windows.Data;
using MapOfEnglishWords.Model;

namespace MapOfEnglishWords.View.Converters
{
    public class WordToNameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var translateEnglish = (bool) values[1];
            var word = (Word) values[0];
            if (word is null)
                return null;
            if (translateEnglish)
            {
                return word.Name;
            }

            return word.Translation;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    //public class WordToNameConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        var translateEnglish = (bool) parameter;
    //        if (translateEnglish)
    //        {
    //            if (value is Word w)
    //                return w.Name;
    //        }
    //        else
    //        {
    //            if (value is Word w)
    //                return w.Translation;
    //        }
    //        return null;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
}