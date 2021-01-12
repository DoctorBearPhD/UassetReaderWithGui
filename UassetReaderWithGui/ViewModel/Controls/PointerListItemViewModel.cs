using GalaSoft.MvvmLight;

namespace UassetReaderWithGui.ViewModel.Controls
{
    public class PointerListItemViewModel : ViewModelBase
    {
        private string _Header;
        public  string  Header { get => _Header; set => Set(ref _Header, value); }

        private int _Location;
        public  int  Location { get => _Location; set => Set(ref _Location, value); }

        private int _Value;
        public  int  Value { get => _Value; set => Set(ref _Value, value); }
    }
}
