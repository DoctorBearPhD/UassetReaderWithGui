using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Linq;
using UassetReaderWithGui.Model;
using UassetReaderWithGui.ViewModel.Controls;

namespace UassetReaderWithGui.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class GuiViewModel : ViewModelBase
    {
        #region Exposed VM Properties

        private ObservableCollection<TreeViewItemViewModel> _treeViewItems;
        public  ObservableCollection<TreeViewItemViewModel>  TreeViewItems { get => _treeViewItems; set => Set(ref _treeViewItems, value); }

        #endregion


        public IDataService ItemsDataService;


        /// <summary>
        /// Initializes a new instance of the GuiViewModel class.
        /// </summary>
        public GuiViewModel(IDataService dataService)
        {
            ////dataService.GetData(
            ////    (di, ex) => {
            ////        TreeViewItems = new ObservableCollection<TreeViewItemViewModel>(
            ////            di.Select( item => new TreeViewItemViewModel { Header = item.Title } )
            ////        );
            ////    } 
            ////);
            
            dataService.GetTreeViewData((items, ex) => { TreeViewItems = items; });
        }
    }
}