using GalaSoft.MvvmLight;

namespace UassetReaderWithGui.ViewModel.Uasset
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class UnknownList1ItemViewModel : ViewModelBase
    {
        /*
         * Reading Unknown List 1: 
	        Id:	3 (KWBattleCharaSetupDataAsset)
	        Name:	DA_KEN_Setup
	        Namespace(?):	/Game/Sound/BGM/TransitionRules/DA_CMN_BGMTransitionRule   (value = 0xB)
	        Size:	1258
	        Pointer To Content:  @BA9
         */

        private int _Id;
        public  int  Id { get => _Id; set => Set(ref _Id, value); }

        private string _Name;
        public  string  Name { get => _Name; set => Set(ref _Name, value); }

        private string _Namespace;
        public  string  Namespace { get => _Namespace; set => Set(ref _Namespace, value); }

        private int _Size;
        public  int  Size { get => _Size; set => Set(ref _Size, value); }

        private int _PtrToContent;
        public  int  PtrToContent { get => _PtrToContent; set => Set(ref _PtrToContent, value); }


        /// <summary>
        /// Initializes a new instance of the UnknownList1ViewModel class.
        /// </summary>
        public UnknownList1ItemViewModel(UassetLib.UnknownList1Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Namespace = item.Namespace;
            Size = item.Size;
            PtrToContent = item.PtrToContent;
        }
    }
}