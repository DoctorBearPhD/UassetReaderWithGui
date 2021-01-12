using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using UassetLib;
using UassetReaderWithGui.Model;
using UassetReaderWithGui.ViewModel.Controls;
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
}