using System.Collections.ObjectModel;
using UassetLib;

namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    public class ArrayPropertyViewModel : UassetPropertyViewModel
    {
        new public const string PROPERTY_NAME = "ArrayProperty";

        // Array Items' property type
        private string _PropertyType;
        public  string  PropertyType { get => _PropertyType; set => Set(ref _PropertyType, value); }

        // Items
        private ObservableCollection<dynamic> _Items;
        public  ObservableCollection<dynamic>  Items { get => _Items; set => Set(ref _Items, value); }


        public ArrayPropertyViewModel(string attrName) : base(attrName: attrName, propName: PROPERTY_NAME)
        {
            Items = new ObservableCollection<dynamic>();
        }

        public ArrayPropertyViewModel(string attrName, ArrayProperty array) : this(attrName)
        {
            // convert ArrayProperty to ViewModel

            Address = (int)array.Address;

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

                    case BoolProperty boolProp:
                        itemVm = new BoolPropertyViewModel(arrayItemName, boolProp);
                        break;

                    case TextProperty textProp:
                        itemVm = new TextPropertyViewModel(attrName:arrayItemName, prop:textProp);
                        break;

                    case IntProperty intProp:
                        itemVm = new IntPropertyViewModel(attrName: arrayItemName, prop: intProp);
                        break;

                    case FloatProperty floatProp:
                        itemVm = new FloatPropertyViewModel(attrName: arrayItemName, prop: floatProp);
                        break;

                    case ObjectProperty objectProp:
                        itemVm = new ObjectPropertyViewModel(attrName: arrayItemName, prop: objectProp);
                        break;

                    case ByteProperty byteProp:
                        itemVm = new BytePropertyViewModel(attrName: arrayItemName, prop: byteProp);
                        break;

                    case StringProperty stringProp:
                        itemVm = new StringPropertyViewModel(attrName: arrayItemName, prop: stringProp);
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