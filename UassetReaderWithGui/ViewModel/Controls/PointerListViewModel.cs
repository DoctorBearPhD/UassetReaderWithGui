using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UassetReaderWithGui.ViewModel.Uasset;

namespace UassetReaderWithGui.ViewModel.Controls
{
    public class PointerListViewModel : ViewModelBase
    {
        private ObservableCollection<PointerListItemViewModel> _items;
        public  ObservableCollection<PointerListItemViewModel>  Items { get => _items; set => Set(ref _items, value); }


        public PointerListViewModel(UassetFileViewModel ufvm)
        {
            Items = new ObservableCollection<PointerListItemViewModel>
            {
                new PointerListItemViewModel
                {
                    Header = "Content Start",
                    Value = ufvm.PreContentSize,
                    Location = 0x18
                },
                new PointerListItemViewModel
                {
                    Header="Declaration Block",
                    Value = ufvm.PtrDeclaration,
                    Location = 0x3D
                },
                new PointerListItemViewModel
                {
                    Header="Unknown List 1",
                    Value = ufvm.PtrUnknownList1,
                    Location = 0x35
                },
                new PointerListItemViewModel
                {
                    Header="Imports List",
                    Value = ufvm.PtrImports,
                    Location = 0x41
                },
                new PointerListItemViewModel
                {
                    Header="UkDepends",
                    Value = ufvm.PtrUkDepends,
                    Location = 0x49
                },
                new PointerListItemViewModel
                {
                    Header="Unknown (UkLoads?)",
                    Value = ufvm.PtrUnknown,
                    Location = 0x8F
                },
                new PointerListItemViewModel
                {
                    Header="Footer",
                    Value = ufvm.PtrFooter,
                    Location = 0x93
                }
            };
        }
    }
}
