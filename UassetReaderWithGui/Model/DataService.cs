using System;
using System.Collections.ObjectModel;
using UassetLib;
using UassetReaderWithGui.ViewModel.Controls;

namespace UassetReaderWithGui.Model
{
    public class DataService : IDataService
    {
        public void GetData(Action<ObservableCollection<DataItem>, Exception> callback)
        {
            // Use this to connect to the actual data service

            var items = new ObservableCollection<DataItem> {
                new DataItem("Runtime Item"),
                new DataItem("Runtime Item"),
                new DataItem("Runtime Item"),
                new DataItem("Runtime Item"),
                new DataItem("Runtime Item")
            };


            callback(items, null);
        }

        public void GetTreeViewData(Action<ObservableCollection<TreeViewItemViewModel>, Exception> callback)
        {
            // Use this to connect to the actual data service

            var items = new ObservableCollection<TreeViewItemViewModel> {
                new TreeViewItemViewModel("Runtime Item"),
                new TreeViewItemViewModel("Runtime Item"),
                new TreeViewItemViewModel("Runtime Item"),
                new TreeViewItemViewModel("Runtime Item"),
                new TreeViewItemViewModel("Runtime Item")
            };


            callback(items, null);
        }

        public void GetStructPropertyData(Action<StructProperty, Exception> callback)
        {
            throw new NotImplementedException();
        }
    }
}