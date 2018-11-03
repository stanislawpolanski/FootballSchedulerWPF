using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace FootballSchedulerWPF.Converters
{
    public class RowToRowNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DataGridRow row = (DataGridRow)value;

            return row.GetIndex() + 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}