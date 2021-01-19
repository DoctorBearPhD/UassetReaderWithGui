using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using UassetLib;
using UassetReaderWithGui.Model;
using UassetReaderWithGui.ViewModel.Controls;
using UassetReaderWithGui.ViewModel.Uasset;

namespace UassetReaderWithGui.ViewModel
{
    public class GuiViewModel : ViewModelBase
    {
        private IDataService _dataService;

        #region Exposed VM Properties

        private UassetFileViewModel _uassetFileVM;
        public  UassetFileViewModel  UassetFileVM { get => _uassetFileVM; set => Set(ref _uassetFileVM, value); }

        private PointerListViewModel _pointerList;
        public  PointerListViewModel  PointerList { get => _pointerList; set => Set(ref _pointerList, value); }

        #endregion


        public GuiViewModel(IDataService dataService)
        {
            _dataService = dataService;

            _dataService.GetUassetFile((uf, ex) => { UassetFileVM = new UassetFileViewModel(uf); });


            PointerList = new PointerListViewModel(UassetFileVM);
        }

        

        //public ObservableCollection<TreeViewItemViewModel> GetTreeViewItems(UassetProperty prop)
        //{
        //    var treeViewItems = new ObservableCollection<TreeViewItemViewModel>();

        //    string propType;
        //    propType = prop.GetType().Name;

        //    switch (propType)
        //    {
        //        case "StructProperty":
        //            treeViewItems.Add(ConvertStructProperty(prop as StructProperty));
        //            break;
        //        case "ArrayProperty":
        //            treeViewItems.Add(ConvertArrayProperty(prop as ArrayProperty));
        //            break;
        //        default:
        //            Console.WriteLine("Unknown property!");
        //            break;
        //    }

            

        //    return treeViewItems;
        //}

        //public TreeViewItemViewModel ConvertStructProperty(StructProperty prop)
        //{
        //    var result = new TreeViewItemViewModel();

        //    var items = new ObservableCollection<TreeViewItemViewModel>();

        //    foreach (var item in prop.Value)
        //    {
        //        items.Add(new TreeViewItemViewModel {
        //            Header = item.Key,
        //            Children = (item.Value is UassetProperty) ? GetTreeViewItems((UassetProperty)item.Value) : null
        //        });
        //    }

        //    result.Header = prop.GetType().Name;
        //    result.Children  = items;
            
        //    return result;
        //}

        //public TreeViewItemViewModel ConvertArrayProperty(ArrayProperty prop)
        //{
        //    var result = new TreeViewItemViewModel();

        //    var items = new ObservableCollection<TreeViewItemViewModel>();

        //    foreach (var item in prop.Items)
        //    {
        //        items.Add(new TreeViewItemViewModel
        //        {
        //            Header = (item is object) ? item.GetType().Name : null
        //        });
        //    }

        //    result.Header = prop.GetType().Name;
        //    result.Children  = items;

        //    return result;
        //}
    }
}