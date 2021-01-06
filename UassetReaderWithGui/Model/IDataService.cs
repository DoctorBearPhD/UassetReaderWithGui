using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UassetReaderWithGui.ViewModel.Controls;

namespace UassetReaderWithGui.Model
{
    public interface IDataService
    {
        /// <summary>
        /// Get the UassetFile at the path specified by startingArg. Must first set starting argument via SetArg(string arg).
        /// If a UassetFile was already created, returns that instead of reading a new one.
        /// </summary>
        /// <returns>The previously read UassetFile or a new one by reading the file at the startingArg path.</returns>
        UassetLib.UassetFile GetUassetFile();

        void SetArg(string arg);

        void GetData(Action<ObservableCollection<DataItem>, Exception> callback);
        void GetTreeViewData(Action<ObservableCollection<TreeViewItemViewModel>, Exception> callback);
        void GetStructPropertyData(Action<UassetLib.StructProperty, Exception> callback);
        void GetStringListData(Action<ObservableCollection<UassetLib.StringProperty>, Exception> callback);
    }
}
