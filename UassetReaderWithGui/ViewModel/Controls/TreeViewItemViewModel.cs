using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace UassetReaderWithGui.ViewModel.Controls
{
    /// <summary>
    /// Represents an hierarchical TreeViewItem that can display and hold many types of objects. 
    /// The items will be represented based on the DataItem's type (using the <see cref="WpfUtil.TreeViewDataTemplateSelector"/>)
    /// <para>
    /// See https://wilberbeast.com/2010/08/24/wpf-mvvm-and-the-treeview-control-using-with-different-hierarchicaldatatemplates-and-datatemplateselector/
    /// </para>
    /// </summary>
    public class TreeViewItemViewModel : ViewModelBase
    {
        public object DataItem { get; private set; }

        public TreeViewItemViewModel Parent { get; set; }
        
        private ObservableCollection<TreeViewItemViewModel> _Children;
        public  ObservableCollection<TreeViewItemViewModel>  Children { get => _Children; set => Set(ref _Children, value); }

        public TreeViewItemViewModel(object dataItem)
        {
            DataItem = dataItem;
        }
    }
}