using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using UassetLib;

namespace UassetReaderWithGui.ViewModel.Uasset
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class UassetFileViewModel : ViewModelBase
    {
        // TODO: Get all parts of the UassetFile and show them.
        
        private ObservableCollection<StringListItemViewModel> _stringList;
        public  ObservableCollection<StringListItemViewModel>  StringList { get => _stringList; set => Set(ref _stringList, value); }
        
        private int _PreContentSize;
        public  int  PreContentSize { get => _PreContentSize; set => Set(ref _PreContentSize, value); }

        #region Pointers

        private int _PtrNoneString;
        public  int  PtrNoneString { get => _PtrNoneString; set => Set(ref _PtrNoneString, value); }

        private int _PtrDeclaration;
        public  int  PtrDeclaration { get => _PtrDeclaration; set => Set(ref _PtrDeclaration, value); }

        private int _PtrUnknownList1;
        public  int  PtrUnknownList1 { get => _PtrUnknownList1; set => Set(ref _PtrUnknownList1, value); }

        private int _PtrImports;
        public  int  PtrImports { get => _PtrImports; set => Set(ref _PtrImports, value); }

        private int _PtrUkDepends;
        public  int  PtrUkDepends { get => _PtrUkDepends; set => Set(ref _PtrUkDepends, value); }

        private int _PtrUnknown;
        public  int  PtrUnknown { get => _PtrUnknown; set => Set(ref _PtrUnknown, value); }

        private int _PtrFooter;
        public  int  PtrFooter { get => _PtrFooter; set => Set(ref _PtrFooter, value); }

        #endregion

        // Create ViewModel for each Model? (UassetFileVM, DeclarationBlockVM, StructPropertyVM, etc)
        /*
            public DeclarationBlock Declaration { get; set; }
            public UnknownList1Block UnknownList1 { get; set; } // Content metadata?
            public ImportBlock Imports { get; set; }
            public UkDepends UkDepends { get; set; }
            // public __?__ UkLoads { get; set; }

            public StructProperty ContentStruct { get; set; }

            
            
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
        /// <summary>
        /// Initializes a new instance of the UassetFileViewModel class.
        /// </summary>
        public UassetFileViewModel()
        {
        }

        public UassetFileViewModel(UassetFile uf)
        {
            SetStringList(uf.StringList);
            PreContentSize = uf.PreContentSize;

            PtrNoneString = (int)uf.PtrNoneString;
            PtrDeclaration = uf.DeclarePtr;
            PtrUnknownList1 = uf.UnknownList1Ptr;
            PtrImports = uf.ImportsListPtr;
            PtrUkDepends = (int)uf.UkDependsPtr;
            PtrUnknown = uf.UnknownPtr;
            PtrFooter = (int)uf.PtrFooter;
        }

        private void SetStringList(ObservableCollection<StringProperty> stringProperties)
        {
            StringList = new ObservableCollection<StringListItemViewModel>();

            StringProperty prop;
            for (var i = 0; i < stringProperties.Count; i++)
            {
                prop = stringProperties[i];
                StringList.Add(new StringListItemViewModel(prop, i));
            }
        }
    }
}