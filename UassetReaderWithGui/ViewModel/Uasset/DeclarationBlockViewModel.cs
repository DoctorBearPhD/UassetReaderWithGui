using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UassetReaderWithGui.ViewModel.Uasset
{
    public class DeclarationBlockViewModel : ViewModelBase
    {
        private ObservableCollection<DeclarationBlockItemViewModel> _items;
        public  ObservableCollection<DeclarationBlockItemViewModel>  Items { get => _items; set => Set(ref _items, value); }


        /// <summary>
        /// Initializes a new instance of the DeclarationBlockViewModel class.
        /// </summary>
        public DeclarationBlockViewModel(UassetLib.DeclarationBlock db)
        {
            Items = new ObservableCollection<DeclarationBlockItemViewModel>();

            foreach (var item in db.Items)
            {
                Items.Add(
                    new DeclarationBlockItemViewModel
                    {
                        Id        = item.Id,
                        Namespace = item.Namespace,
                        Type      = item.Type,
                        Name      = item.Name,
                        Depends   = item.Depends,
                        Item6     = item.Item6,
                        Items     = item.Items
                    }
                );
            }
        }
    }

    public class DeclarationBlockItemViewModel : ViewModelBase
    {
        private int _Id;
        public  int  Id { get => _Id; set => Set(ref _Id, value); }

        private string _Namespace;
        public  string  Namespace { get => _Namespace; set => Set(ref _Namespace, value); }

        private string _Type;
        public  string  Type { get => _Type; set => Set(ref _Type, value); }

        private string _Name;
        public  string  Name { get => _Name; set => Set(ref _Name, value); }
        
        private int _Depends;
        public  int  Depends { get => _Depends; set => Set(ref _Depends, value); }
        
        private int _Item6;
        public  int  Item6 { get => _Item6; set => Set(ref _Item6, value); }

        private int[] _Items = new int[7];
        public  int[]  Items { get => _Items; set => Set(ref _Items, value); }
    }
}