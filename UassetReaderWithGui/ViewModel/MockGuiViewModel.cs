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

        private ObservableCollection<StringListItemViewModel> _stringList;
        public  ObservableCollection<StringListItemViewModel>  StringList { get => _stringList; set => Set(ref _stringList, value); }

        #endregion


        /// <summary>
        /// Initializes a new instance of the MockGuiViewModel class.
        /// </summary>
        public MockGuiViewModel()
        {
            _dataService = SimpleIoc.Default.GetInstance<IDataService>();

            _dataService.GetStringListData(SetStringList);
        }

        private void SetStringList(ObservableCollection<StringProperty> stringProperties, Exception ex)
        {
            StringList = new ObservableCollection<StringListItemViewModel>();

            StringProperty prop;
            for (var i = 0; i < stringProperties.Count; i++)
            {
                prop = stringProperties[i];
                StringList.Add(new StringListItemViewModel(prop, i));
            }
        }
    }
}