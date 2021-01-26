using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UassetReaderWithGui.WpfUtil.Converters
{
    [ValueConversion(sourceType: typeof(float), targetType: typeof(string))]
    public class FloatToHexFormattedStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is float vf))
                return null;

            return $"0x{BitConverter.ToInt32(BitConverter.GetBytes(vf), 0):X}"; // convert the float to bytes, convert the bytes to int, format int as hex string
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
                return null;

            var strValue = (string)value;

            if (!strValue.StartsWith("0x"))
                return null;

            var strippedString = strValue.Split(new string[] { "0x" }, StringSplitOptions.RemoveEmptyEntries)[0]; // split the string on the "0x", and don't include the empty string in the resulting array. set the result to just the remaining string.

            // convert hex string to int, convert int to bytes, convert bytes to float
            var result = BitConverter.ToSingle(
                BitConverter.GetBytes(
                    int.Parse(strippedString, NumberStyles.HexNumber)
                ), 0);

            return result;
        }
    }
}
