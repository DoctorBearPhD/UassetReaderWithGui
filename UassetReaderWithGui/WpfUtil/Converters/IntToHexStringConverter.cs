using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UassetReaderWithGui.WpfUtil.Converters
{
    [ValueConversion(sourceType: typeof(int), targetType: typeof(string))]
    public class IntToHexStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int))
                return null;

            return $"{(int)value:X}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
                return null;

            return int.Parse((string)value, NumberStyles.HexNumber);
        }
    }
}
