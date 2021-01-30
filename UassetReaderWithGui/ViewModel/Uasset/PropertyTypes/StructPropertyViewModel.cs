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


        public StructPropertyViewModel(string attrName) : base(attrName: attrName, propName: PROPERTY_NAME)
        {
            Items = new ObservableCollection<UassetPropertyViewModel>();
        }

        public StructPropertyViewModel(string attrName, StructProperty @struct) : this(attrName)
        {
            // convert StructProperty.Value's items to list of UassetPropertyViewModels
            var structAttributes = @struct.Value.Keys.ToList();//.Where(key => { return @struct.Value[key] is UassetProperty; });
            var structVal = @struct.Value;

            object value;

            foreach (var attr in structAttributes)
            {
                value = structVal[attr];

                #region Special Cases

                if (attr == "StringAssetReference")
                {
                    PropertyName = "Special StructProperty";
                    Items.Add(new StringPropertyViewModel(attr, (string)value));

                    continue;
                }

                if (value is VectorStructProperty vsp)
                {
                    Items.Add(new VectorStructPropertyViewModel(attrName: attr, prop: vsp));
                    continue;
                }

                #endregion (Special Cases)

                // TODO: Add string, text, float, <others?>
                if (value is StructProperty v)
                    Items.Add(new StructPropertyViewModel(attrName: attr, @struct: v));

                else if (value is ArrayProperty a)
                    Items.Add(new ArrayPropertyViewModel(attrName: attr, array: a));

                else if (value is BoolProperty boolProp)
                    Items.Add(new BoolPropertyViewModel(attrName: attr, prop: boolProp));

                else if (value is TextProperty t)
                    Items.Add(new TextPropertyViewModel(attrName: attr, prop: t));

                else if (value is IntProperty i)
                    Items.Add(new IntPropertyViewModel(attrName: attr, prop: i));

                else if (value is ObjectProperty o)
                    Items.Add(new ObjectPropertyViewModel(attrName: attr, prop: o));

                else if (value is ByteProperty byteProp)
                    Items.Add(new BytePropertyViewModel(attrName: attr, prop: byteProp));

                else if (value is StringProperty s)
                    Items.Add(new StringPropertyViewModel(attrName: attr, prop: s));

                else if (value is UassetProperty)
                    Items.Add(new UassetPropertyViewModel(attrName: attr, propName: value.GetType().Name));
            }
        }
    }
}