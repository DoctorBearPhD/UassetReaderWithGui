namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    //TODO: Conform this to the other Property VMs' style, and make a separate VM for things like the "StringAssetReference" special case.
    public class StringPropertyViewModel : UassetPropertyViewModel
    {
        new public const string PROPERTY_NAME = "StrProperty";

        private string _Value;
        public  string  Value { get => _Value; set => Set(ref _Value, value); }

        /// <summary>
        /// Initializes a new instance of the StringPropertyViewModel class. This constructor is used for StringAssetReference.
        /// Can't call the base class to assign the PropertyName and AttributeName because StringAssetReference doesn't have attribute name.
        /// </summary>
        public StringPropertyViewModel(string val)
        {
            PropertyName = PROPERTY_NAME;
            Value = val;
        }

        /// <summary>
        /// Initializes a new instance of the StringPropertyViewModel class.
        /// </summary>
        public StringPropertyViewModel(string attrName, UassetLib.StringProperty prop) : base(attrName: attrName, propName: PROPERTY_NAME)
        {
            Value = prop.Value;
        }

        public StringPropertyViewModel(string attrName, string val) : this(val)
        {
            AttributeName = attrName;
        }
    }
}