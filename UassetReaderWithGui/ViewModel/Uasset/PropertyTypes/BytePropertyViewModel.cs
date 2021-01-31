using System;
using System.Collections.Generic;
using System.Linq;

namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
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
            Address = (int)prop.Address;

            IsArrayOfBytes = prop.IsArrayOfBytes;

            if (IsArrayOfBytes)
            {
                ByteArrayValue = prop.Value;
                return;
            }

            EnumCategory = prop.EnumCategory;
            EnumValue    = prop.EnumValue;
        }
    }
}
