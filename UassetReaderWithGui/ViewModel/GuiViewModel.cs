using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using UassetLib;
using UassetReaderWithGui.Model;
using UassetReaderWithGui.ViewModel.Controls;
using UassetReaderWithGui.ViewModel.Uasset;

namespace UassetReaderWithGui.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class GuiViewModel : ViewModelBase
    {
        #region Exposed VM Properties

        private ObservableCollection<TreeViewItemViewModel> _treeViewItems;
        public  ObservableCollection<TreeViewItemViewModel>  TreeViewItems { get => _treeViewItems; set => Set(ref _treeViewItems, value); }

        private UassetFileViewModel _uassetFileVM;
        public  UassetFileViewModel  UassetFileVM { get => _uassetFileVM; set => Set(ref _uassetFileVM, value); }

        private ObservableCollection<StringListItemViewModel> _stringList;
        public ObservableCollection<StringListItemViewModel> StringList { get => _stringList; set => Set(ref _stringList, value); }

        #endregion


        public IDataService _dataService;


        /// <summary>
        /// Initializes a new instance of the GuiViewModel class.
        /// </summary>
        public GuiViewModel(IDataService dataService)
        {
            _dataService = dataService;

            ////dataService.GetData(
            ////    (di, ex) => {
            ////        TreeViewItems = new ObservableCollection<TreeViewItemViewModel>(
            ////            di.Select( item => new TreeViewItemViewModel { Header = item.Title } )
            ////        );
            ////    } 
            ////);

            ////dataService.GetTreeViewData((items, ex) => { TreeViewItems = items; });




            // TODO: Get all parts of the UassetFile and show them.




            //dataService.GetStructPropertyData(
            //    (prop, ex) =>
            //    {
            //        TreeViewItems = GetTreeViewItems(prop);
            //    }
            //);

            //_dataService = SimpleIoc.Default.GetInstance<IDataService>();

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

        public ObservableCollection<TreeViewItemViewModel> GetTreeViewItems(UassetProperty prop)
        {
            var treeViewItems = new ObservableCollection<TreeViewItemViewModel>();

            string propType;
            propType = prop.GetType().Name;

            switch (propType)
            {
                case "StructProperty":
                    treeViewItems.Add(ConvertStructProperty(prop as StructProperty));
                    break;
                case "ArrayProperty":
                    treeViewItems.Add(ConvertArrayProperty(prop as ArrayProperty));
                    break;
                default:
                    Console.WriteLine("Unknown property!");
                    break;
            }

            

            return treeViewItems;
        }

        public TreeViewItemViewModel ConvertStructProperty(StructProperty prop)
        {
            var result = new TreeViewItemViewModel();

            var items = new ObservableCollection<TreeViewItemViewModel>();

            foreach (var item in prop.Value)
            {
                items.Add(new TreeViewItemViewModel {
                    Header = item.Key,
                    Items = (item.Value is UassetProperty) ? GetTreeViewItems((UassetProperty)item.Value) : null
                });
            }

            result.Header = prop.GetType().Name;
            result.Items  = items;
            
            return result;
        }

        public TreeViewItemViewModel ConvertArrayProperty(ArrayProperty prop)
        {
            var result = new TreeViewItemViewModel();

            var items = new ObservableCollection<TreeViewItemViewModel>();

            foreach (var item in prop.Items)
            {
                items.Add(new TreeViewItemViewModel
                {
                    Header = (item is object) ? item.GetType().Name : null
                });
            }

            result.Header = prop.GetType().Name;
            result.Items  = items;

            return result;
        }
    }
}