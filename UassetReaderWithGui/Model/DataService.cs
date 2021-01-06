using System;
using System.Collections.ObjectModel;
using System.IO;
using UassetLib;
using UassetReaderWithGui.ViewModel.Controls;

namespace UassetReaderWithGui.Model
{
    public class DataService : IDataService
    {
        private UassetFile uassetFile;
        private string startingArg;

        public void SetArg(string arg)
        {
            startingArg = arg;
        }

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

        public void GetStringListData(Action<ObservableCollection<StringProperty>, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public UassetFile GetUassetFile()
        {
            if (uassetFile != null) return uassetFile;

            BinaryReader br = new BinaryReader(File.OpenRead(startingArg));

            uassetFile = new UassetFile();
            uassetFile.ReadUasset(ref br);

            return uassetFile;
        }
    }
}