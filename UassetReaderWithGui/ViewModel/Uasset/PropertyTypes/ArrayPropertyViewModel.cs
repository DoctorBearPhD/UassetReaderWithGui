using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using UassetLib;

namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    // TODO
    public class ArrayPropertyViewModel : UassetPropertyViewModel
    {
        new public const string PROPERTY_NAME = "ArrayProperty";

        // Array Items' property type
        private string _PropertyType;
        public  string  PropertyType { get => _PropertyType; set => Set(ref _PropertyType, value); }

        // Items
        private ObservableCollection<dynamic> _Items;
        public  ObservableCollection<dynamic>  Items { get => _Items; set => Set(ref _Items, value); }


        /// <summary>
        /// Initializes a new instance of the ArrayPropertyViewModel class.
        /// </summary>
        public ArrayPropertyViewModel()
        {
            PropertyName = PROPERTY_NAME;
            Items = new ObservableCollection<dynamic>();
        }

        public ArrayPropertyViewModel(string attrName) : this()
        {
            AttributeName = attrName;
        }

        public ArrayPropertyViewModel(string attrName, ArrayProperty array) : this(attrName)
        {
            // convert ArrayProperty to ViewModel

            PropertyType = array.PropertyType;

            UassetPropertyViewModel itemVm;
            string arrayItemName;

            foreach (var item in array.Items)
            {
                arrayItemName = $"[Item {array.Items.IndexOf(item)}]";

                switch (item)
                {
                    case StructProperty structProp:
                        itemVm = new StructPropertyViewModel(arrayItemName, structProp);
                        break;

                    case ArrayProperty arrayProp:
                        itemVm = new ArrayPropertyViewModel(arrayItemName, arrayProp);
                        break;

                    default:
                        itemVm = new UassetPropertyViewModel(arrayItemName, item.GetType().Name);
                        break;
                }


                Items.Add(itemVm);
            }
        }
    }
}