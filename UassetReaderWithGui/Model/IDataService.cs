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
        void GetData(Action<ObservableCollection<DataItem>, Exception> callback);
        void GetTreeViewData(Action<ObservableCollection<TreeViewItemViewModel>, Exception> callback);
        void GetStructPropertyData(Action<UassetLib.StructProperty, Exception> callback);
    }
}
