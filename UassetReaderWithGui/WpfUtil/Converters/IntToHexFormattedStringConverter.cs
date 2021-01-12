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
    public class IntToHexFormattedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int))
                return null;

            return $"0x{(int)value:X}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
                return null;

            var strValue = (string)value;

            if (!strValue.StartsWith("0x"))
                return null;

            var result = strValue.Split(new string[] { "0x" }, StringSplitOptions.RemoveEmptyEntries)[0]; // split the string on the "0x", and don't include the empty string in the resulting array. set the result to just the remaining string.

            return int.Parse(result, NumberStyles.HexNumber);
        }
    }
}
