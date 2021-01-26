using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    public class IntPropertyViewModel : UassetPropertyViewModel
    {
        new public const string PROPERTY_NAME = "IntProperty";

        private int _Value;
        public  int  Value { get => _Value; set => Set(ref _Value, value); }

        public IntPropertyViewModel(string attrName, UassetLib.IntProperty prop) : base(attrName: attrName, propName: PROPERTY_NAME)
        {
            Value = prop.Value;
        }
    }
}
