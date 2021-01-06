using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UassetLib;
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

        public void GetStructPropertyData(Action<StructProperty, Exception> callback)
        {
            var structProp = new StructProperty();
            var value = new Dictionary<string, object>
            {
                ["Attribute"] = new ArrayProperty()
                {
                    PropertyType = typeof(StructProperty).Name,
                    Items = new ObservableCollection<dynamic> { new StructProperty(), new StructProperty(), new StructProperty() }
                }
            };

            structProp.Value = value;

            callback(structProp, null);
        }
    }
}