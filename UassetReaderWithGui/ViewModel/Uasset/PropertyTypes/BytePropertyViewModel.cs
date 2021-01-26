using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    // TODO: Until we test and implement (in the UassetLib) a way to determine if a ByteProperty is an Enum, we'll have to do it here!
    public class BytePropertyViewModel : UassetPropertyViewModel
    {
        new public const string PROPERTY_NAME = "ByteProperty";

        public bool IsArrayOfBytes = false; // is the ByteProperty an Enum or an array of bytes?

        private string _EnumCategory;
        public  string  EnumCategory { get => _EnumCategory; set => Set(ref _EnumCategory, value); }

        private string _EnumValue;
        public  string  EnumValue { get => _EnumValue; set => Set(ref _EnumValue, value); }

        private byte[] _ByteArrayValue;
        public  byte[]  ByteArrayValue { get => _ByteArrayValue; set => Set(ref _ByteArrayValue, value); }


        public BytePropertyViewModel(string attrName, UassetLib.ByteProperty prop) : base(attrName: attrName, propName: PROPERTY_NAME)
        {
            // TODO: Temp until Todo item at top of the file is finished.
            #region Temp

            // Get the StringList as an array of strings

            string[] strings = { };

            GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<Model.IDataService>().GetUassetFile(
                (uf, ex) => {
                    strings = uf.StringList.Select
                        (s => s.Value).ToArray();
                    }
                );

            // determine size of ByteProperty's value
            int size = prop.Value.Length;

            // determine if ByteProperty is an Enum based on the number of bytes
            if (size > 16) // if there are more than 16 bytes, then it isn't an Enum, it's an array of bytes... Maybe...
                IsArrayOfBytes = true;

            if (IsArrayOfBytes)
            {
                ByteArrayValue = prop.Value;
                return;
            }

            // verify there are exactly 16 bytes
            if (size != 16)
                throw new Exception();

            // if it isn't an array of bytes, it's an Enum; assign values

            // item 1 in byte array is the EnumCategory (bytes 0-7)
            var item1 = new List<byte>(prop.Value.Take(8)).ToArray();
            // item 2 in byte array is the EnumValue (bytes 8-15)
            var item2 = new List<byte>(prop.Value.Skip(8)).ToArray();

            var item1Value = BitConverter.ToInt32(item1, 0);
            var item2Value = BitConverter.ToInt32(item2, 0);

            if (item1Value < strings.Length && item2Value < strings.Length)
            {
                EnumCategory = strings[item1Value];
                EnumValue    = strings[item2Value];
            }

            #endregion (Temp)

            // TODO: after top-of-file Todo list item is finished, assign class properties to corresponding ByteProperty properties.
        }
    }
}
