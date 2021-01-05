using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace UassetReaderWithGui.ViewModel.Controls
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class TreeViewItemViewModel : ViewModelBase
    {
        private string _header;
        public  string  Header { get => _header; set => Set(ref _header, value); }

        private ObservableCollection<TreeViewItemViewModel> _items;
        public  ObservableCollection<TreeViewItemViewModel>  Items { get => _items; set => Set(ref _items, value); }


        /// <summary>
        /// Initializes a new instance of the TreeViewItemViewModel class.
        /// </summary>
        public TreeViewItemViewModel()
        {
        }

        public TreeViewItemViewModel(string header)
        {
            Header = header;
        }
    }
}