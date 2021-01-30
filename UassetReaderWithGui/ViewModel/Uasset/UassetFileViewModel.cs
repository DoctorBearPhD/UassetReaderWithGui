using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using UassetLib;
using UassetReaderWithGui.ViewModel.Uasset.PropertyTypes;

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

        #region Pointers

        private int _PreContentSize;
        public  int  PreContentSize { get => _PreContentSize; set => Set(ref _PreContentSize, value); }

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

        private DeclarationBlockViewModel _DeclarationBlock;
        public  DeclarationBlockViewModel  DeclarationBlock { get => _DeclarationBlock; set => Set(ref _DeclarationBlock, value); }

        private ObservableCollection<UnknownList1ItemViewModel> _UnknownList1;
        public  ObservableCollection<UnknownList1ItemViewModel>  UnknownList1 { get => _UnknownList1; set => Set(ref _UnknownList1, value); }

        private ObservableCollection<ImportBlockItemViewModel> _ImportBlock;
        public  ObservableCollection<ImportBlockItemViewModel>  ImportBlock { get => _ImportBlock; set => Set(ref _ImportBlock, value); }

        private ObservableCollection<string> _UkDepends;
        public  ObservableCollection<string>  UkDepends { get => _UkDepends; set => Set(ref _UkDepends, value); }

        private StructPropertyViewModel _ContentStruct;
        public  StructPropertyViewModel  ContentStruct { get => _ContentStruct; set => Set(ref _ContentStruct, value); }


        // TODO: When you can find a file with UkLoads, add a viewer for it.
        /*
            // public __?__ UkLoads { get; set; }

            public int Unknown1;
            public int ContentCount;
            public int Unknown2;

            public byte[] Checksum;
            public byte[] FooterBytes;
         */

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

            DeclarationBlock = new DeclarationBlockViewModel(uf.Declaration);
            SetUnknownList1(uf.UnknownList1);
            SetImportBlock(uf.Imports, uf.StringList);
            SetUkDepends(uf.UkDepends);

            ContentStruct = new StructPropertyViewModel("<Main Content>", uf.ContentStruct);
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

        private void SetUnknownList1(UnknownList1Block list)
        {
            UnknownList1 = new ObservableCollection<UnknownList1ItemViewModel>();

            foreach (var item in list.Items)
            {
                UnknownList1.Add(new UnknownList1ItemViewModel(item));
            }
        }

        private void SetImportBlock(ImportBlock imports, ObservableCollection<StringProperty> stringList)
        {
            ImportBlock = new ObservableCollection<ImportBlockItemViewModel>();

            foreach (var item in imports.Items)
            {
                ImportBlock.Add(new ImportBlockItemViewModel(item, stringList));
            }
        }

        private void SetUkDepends(UkDepends ukDepends)
        {
            UkDepends = new ObservableCollection<string>();

            foreach (var item in ukDepends.Items)
            {
                UkDepends.Add(System.Text.Encoding.UTF8.GetString(item, 0, item.Length - 1));
            }
        }
    }
}