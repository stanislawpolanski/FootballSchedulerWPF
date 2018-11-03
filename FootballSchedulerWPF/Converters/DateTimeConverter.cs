using System;
using System.Globalization;
using System.Windows.Data;

namespace FootballSchedulerWPF.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            return date.ToString("yyyy-MM-dd HH:mm");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string stringValue = value.ToString();
            DateTime resultDateTime;
            if (DateTime.TryParse(stringValue, out resultDateTime))
                return resultDateTime;
            return value;
        }
    }
}
