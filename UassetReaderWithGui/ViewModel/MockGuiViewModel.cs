using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using UassetLib;
using UassetReaderWithGui.Model;
using UassetReaderWithGui.ViewModel.Uasset;
using UassetReaderWithGui.ViewModel.Uasset.PropertyTypes;

namespace UassetReaderWithGui.ViewModel
{
    public class MockGuiViewModel : ViewModelBase
    {
        private IDataService _dataService;

        #region Exposed VM Properties

        private UassetFileViewModel _uassetFileVM;
        public  UassetFileViewModel  UassetFileVM { get => _uassetFileVM; set => Set(ref _uassetFileVM, value); }

        private PointerListViewModel _pointerList;
        public  PointerListViewModel  PointerList { get => _pointerList; set => Set(ref _pointerList, value); }

        #endregion


        /// <summary>
        /// Initializes a new instance of the MockGuiViewModel class.
        /// </summary>
        public MockGuiViewModel()
        {
            _dataService = SimpleIoc.Default.GetInstance<IDataService>();

            _dataService.GetUassetFile( (uf, ex) => { UassetFileVM = new UassetFileViewModel(uf); } );


            PointerList = new PointerListViewModel(UassetFileVM);
        }

    }

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