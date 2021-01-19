using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Data;
using UassetReaderWithGui.Model;
using UassetReaderWithGui.ViewModel.Controls;
using UassetReaderWithGui.ViewModel.Uasset;

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

        private TreeViewViewModel _TreeViewModel;
        public  TreeViewViewModel  TreeViewModel { get => _TreeViewModel; set => Set(ref _TreeViewModel, value); }

        #endregion


        public MockGuiViewModel()
        {
            _dataService = SimpleIoc.Default.GetInstance<IDataService>();

            _dataService.GetUassetFile( (uf, ex) => { UassetFileVM = new UassetFileViewModel(uf); } );


            PointerList   = new PointerListViewModel(UassetFileVM);
            TreeViewModel = new    TreeViewViewModel(UassetFileVM.ContentStruct);
        }

        
    }
}