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

            var topLevelItem = new TreeViewItemViewModel(contentStructVm);   // top-level StructProperty
            topLevelItem.Children = GetTreeViewItemViewModels(contentStructVm.Items, topLevelItem); // get children
            


            TreeViewItems.Add(topLevelItem); // add top-level prop to tree
        }
        
        public ObservableCollection<TreeViewItemViewModel> GetTreeViewItemViewModels(IEnumerable<object> items, TreeViewItemViewModel parent)
        {
            var result = new ObservableCollection<TreeViewItemViewModel>();

            TreeViewItemViewModel tvivm;
            foreach (var item in items)
            {
                tvivm = new TreeViewItemViewModel(dataItem: item)
                {
                    Parent = parent
                };

                if (item is StructPropertyViewModel structItem)
                {
                    tvivm.Children = GetTreeViewItemViewModels(structItem.Items, tvivm);
                }
                else if (item is ArrayPropertyViewModel arrayItem)
                {
                    tvivm.Children = GetTreeViewItemViewModels(arrayItem.Items, tvivm);
                }

                result.Add(tvivm);
            }

            return result;
        }
    }
}