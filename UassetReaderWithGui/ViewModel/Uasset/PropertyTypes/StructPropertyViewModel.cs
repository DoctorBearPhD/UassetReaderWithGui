using System.Collections.ObjectModel;
using UassetLib;
using System.Linq;

namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    /// <summary>
    /// Represents a <see cref="StructProperty"/>.
    /// </summary>
    public class StructPropertyViewModel : UassetPropertyViewModel
    {
        new public const string PROPERTY_NAME = "StructProperty";

        private int _Address;
        public  int  Address { get => _Address; set => Set(ref _Address, value); }

        private ObservableCollection<UassetPropertyViewModel> _Items;
        public  ObservableCollection<UassetPropertyViewModel>  Items { get => _Items; set => Set(ref _Items, value); }


        /// <summary>
        /// Initializes a new instance of the StructViewModel class.
        /// </summary>
        public StructPropertyViewModel()
        {
            Items = new ObservableCollection<UassetPropertyViewModel>();
        }

        /// <summary>
        /// Initializes a new instance of the StructViewModel class, initialized with an Attribute Name.
        /// </summary>
        public StructPropertyViewModel(string attr) : this()
        {
            AttributeName = attr;
        }

        public StructPropertyViewModel(string attrName, StructProperty @struct) : this(attrName)
        {
            // convert StructProperty.Value's items to list of UassetPropertyViewModels
            var structAttributes = @struct.Value.Keys.Where(key => { return @struct.Value[key] is UassetProperty; });
            var structVal = @struct.Value;

            object value;

            foreach(var attr in structAttributes)
            {
                value = structVal[attr];

                if (value is StructProperty v)
                    Items.Add(new StructPropertyViewModel(attrName: attr, @struct: v));
                else if (value is UassetProperty)
                    Items.Add(new UassetPropertyViewModel(propName: value.GetType().Name) { AttributeName = attr });
            }
        }
    }
}