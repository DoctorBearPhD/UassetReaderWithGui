using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace UassetReaderWithGui.ViewModel.Uasset
{
    public class ImportBlockItemViewModel : ViewModelBase
    {
        private int _ItemAsInt;
        public  int  ItemAsInt { get => _ItemAsInt; set => Set(ref _ItemAsInt, value); }

        private string _ItemAsString;
        public  string  ItemAsString { get => _ItemAsString; set => Set(ref _ItemAsString, value); }


        public ImportBlockItemViewModel(int item, UassetLib.DeclarationBlock declaration)
        {
            ItemAsInt = item;
            ItemAsString = declaration.Items[ItemAsInt].Name;
        }
    }
}