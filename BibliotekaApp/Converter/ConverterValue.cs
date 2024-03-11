using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BibliotekaApp.Converter
{
    public class ConverterValue : IValueConverter
    {
        // при true - показывать подсказку, при false - скрывать
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Trace.WriteLine($"Конвертация данных - Convert: Значение {value}");
            if ((bool)value == true)
            {
                Trace.WriteLine($"Вернуть Visibility.Visible");
                return Visibility.Visible;
            }
            else
            {
                Trace.WriteLine($"Вернуть Visibility.Collapsed");
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Trace.WriteLine($"Конвертация данных - ConvertBack: Значение {value}");
            Trace.WriteLine($"Вернуть null");
            return null;
        }
    }
}
