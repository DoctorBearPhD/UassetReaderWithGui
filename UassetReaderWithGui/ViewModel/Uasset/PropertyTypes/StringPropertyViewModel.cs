using GalaSoft.MvvmLight;

namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class StringPropertyViewModel : UassetPropertyViewModel
    {
        new public const string PROPERTY_NAME = "StrProperty";

        private string _Value;
        public  string  Value { get => _Value; set => Set(ref _Value, value); }

        /// <summary>
        /// Initializes a new instance of the StringPropertyViewModel class.
        /// </summary>
        public StringPropertyViewModel(string val)
        {
            PropertyName = PROPERTY_NAME;
            Value = val;
        }

        public StringPropertyViewModel(string attrName, string val) : this(val)
        {
            AttributeName = attrName;
        }
    }
}