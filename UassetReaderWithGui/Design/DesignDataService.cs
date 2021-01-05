using System;
using System.Collections.ObjectModel;
using UassetReaderWithGui.Model;
using UassetReaderWithGui.ViewModel.Controls;

namespace UassetReaderWithGui.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<ObservableCollection<DataItem>, Exception> callback)
        {
            // Use this to create design time data

            var items = new ObservableCollection<DataItem> {
                new DataItem("Design-time Item 1"),
                new DataItem("Design-time Item 2"),
                new DataItem("Design-time Item 3"),
                new DataItem("Design-time Item 4"),
                new DataItem("Design-time Item 5")
            };

            callback(items, null);
        }

        public void GetTreeViewData(Action<ObservableCollection<TreeViewItemViewModel>, Exception> callback)
        {
            // Use this to create design time data

            var items = new ObservableCollection<TreeViewItemViewModel> {
                new TreeViewItemViewModel("Design-time Item 1"),
                new TreeViewItemViewModel("Design-time Item 2"),
                new TreeViewItemViewModel("Design-time Item 3")
                {
                    Items = new ObservableCollection<TreeViewItemViewModel>
                    {
                        new TreeViewItemViewModel("Design-time Sub-item 1"),
                        new TreeViewItemViewModel("Design-time Sub-item 2"),
                        new TreeViewItemViewModel("Design-time Sub-item 3")
                    }
                },
                new TreeViewItemViewModel("Design-time Item 4"),
                new TreeViewItemViewModel("Design-time Item 5")
            };

            callback(items, null);
        }
    }
}