using GalaSoft.MvvmLight;

namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class StringPropertyViewModel : ViewModelBase
    {
        private string _Value;
        public  string  Value { get => _Value; set => Set(ref _Value, value); }

        /// <summary>
        /// Initializes a new instance of the StringPropertyViewModel class.
        /// </summary>
        public StringPropertyViewModel(string val)
        {
            Value = val;
        }
    }
}