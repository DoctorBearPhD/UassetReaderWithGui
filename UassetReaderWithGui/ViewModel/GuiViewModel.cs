using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using UassetLib;
using UassetReaderWithGui.Model;
using UassetReaderWithGui.ViewModel.Controls;
using UassetReaderWithGui.ViewModel.Uasset;

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

        private UassetFileViewModel _uassetFileVM;
        public  UassetFileViewModel  UassetFileVM { get => _uassetFileVM; set => Set(ref _uassetFileVM, value); }

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

            ////dataService.GetTreeViewData((items, ex) => { TreeViewItems = items; });




            // TODO: Get all parts of the UassetFile and show them.

            // Create ViewModel for each Model? (UassetFileVM, DeclarationBlockVM, StructPropertyVM, etc)
            /*
                private const int BYTE_GROUP_SIZE = 4;

                private const int LOC_PTR_CONTENT = 0x18;
                private const int LOC_PTR_FOOTER   = 0x93;

                public ObservableCollection<StringProperty> StringList { get; set; }
                public DeclarationBlock Declaration { get; set; }
                public UnknownList1Block UnknownList1 { get; set; } // Content metadata?
                public ImportBlock Imports { get; set; }
                public UkDepends UkDepends { get; set; }
                // public __?__ UkLoads { get; set; }

                public StructProperty ContentStruct { get; set; }

                public long PtrFooter;
                public long PtrNoneString;
                public long NoneIndex;

                public int PreContentSize; // alternatively, pointer to start of content
                public int Unknown1;
                public int StringListCount;
                public int StringListPtr;
                public int UnknownList1Count;
                public int UnknownList1Ptr;
                public int DeclareCount;
                public int DeclarePtr;
                public int ImportsListPtr;
                public int UkDependsCount;
                public long UkDependsPtr;
                public int ContentCount;
                public int Unknown2;
                public long UnknownPtrLocation;
                public int UnknownPtr;

                public byte[] Checksum;
                public byte[] FooterBytes;
             */



            dataService.GetStructPropertyData(
                (prop, ex) =>
                {
                    TreeViewItems = GetTreeViewItems(prop);
                }
            );
        }

        public ObservableCollection<TreeViewItemViewModel> GetTreeViewItems(UassetProperty prop)
        {
            var treeViewItems = new ObservableCollection<TreeViewItemViewModel>();

            string propType;
            propType = prop.GetType().Name;

            switch (propType)
            {
                case "StructProperty":
                    treeViewItems.Add(ConvertStructProperty(prop as StructProperty));
                    break;
                case "ArrayProperty":
                    treeViewItems.Add(ConvertArrayProperty(prop as ArrayProperty));
                    break;
                default:
                    Console.WriteLine("Unknown property!");
                    break;
            }

            

            return treeViewItems;
        }

        public TreeViewItemViewModel ConvertStructProperty(StructProperty prop)
        {
            var result = new TreeViewItemViewModel();

            var items = new ObservableCollection<TreeViewItemViewModel>();

            foreach (var item in prop.Value)
            {
                items.Add(new TreeViewItemViewModel {
                    Header = item.Key,
                    Items = (item.Value is UassetProperty) ? GetTreeViewItems((UassetProperty)item.Value) : null
                });
            }

            result.Header = prop.GetType().Name;
            result.Items  = items;
            
            return result;
        }

        public TreeViewItemViewModel ConvertArrayProperty(ArrayProperty prop)
        {
            var result = new TreeViewItemViewModel();

            var items = new ObservableCollection<TreeViewItemViewModel>();

            foreach (var item in prop.Items)
            {
                items.Add(new TreeViewItemViewModel
                {
                    Header = (item is object) ? item.GetType().Name : null
                });
            }

            result.Header = prop.GetType().Name;
            result.Items  = items;

            return result;
        }
    }
}