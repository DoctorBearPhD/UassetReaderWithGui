using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UassetReaderWithGui.ViewModel.Uasset.PropertyTypes;

namespace UassetReaderWithGui.ViewModel.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class TreeViewViewModel : ViewModelBase
    {
        private ObservableCollection<TreeViewItemViewModel> _TreeViewItems;
        public  ObservableCollection<TreeViewItemViewModel>  TreeViewItems { get => _TreeViewItems; set => Set(ref _TreeViewItems, value); }


        /// <summary>
        /// Initializes a new instance of the TreeView's ViewModel.
        /// </summary>
        public TreeViewViewModel(StructPropertyViewModel contentStructVm)
        {
            TreeViewItems = new ObservableCollection<TreeViewItemViewModel>();

            var topLevelItem = new TreeViewItemViewModel(contentStructVm)   // top-level StructProperty
            {
                Children = GetTreeViewItemViewModels(contentStructVm.Items) // get children
            }; 

            TreeViewItems.Add(topLevelItem); // add top-level prop to tree
        }
        
        public ObservableCollection<TreeViewItemViewModel> GetTreeViewItemViewModels(IEnumerable<object> items)
        {
            var result = new ObservableCollection<TreeViewItemViewModel>();

            foreach (var item in items)
            {
                result.Add(new TreeViewItemViewModel(item));
            }

            return result;
        }
    }
}