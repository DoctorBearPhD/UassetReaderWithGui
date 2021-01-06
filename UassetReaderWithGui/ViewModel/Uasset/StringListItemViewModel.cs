using GalaSoft.MvvmLight;
using UassetLib;

namespace UassetReaderWithGui.ViewModel.Uasset
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class StringListItemViewModel : ViewModelBase
    {
        // ID
        private int _Id;
        public  int  Id { get => _Id; set => Set(ref _Id, value); }

        // String
        private string _Value;
        public  string  Value { get => _Value; set => Set(ref _Value, value); }

        // StringProperty
        private StringProperty _stringProperty;
        
        
        /// <summary>
        /// Initializes a new instance of the StringListItemViewModel class.
        /// </summary>
        public StringListItemViewModel(StringProperty prop, int id)
        {
            _stringProperty = prop;
            Value           = prop.Value;
            Id              = id;
        }
    }
}