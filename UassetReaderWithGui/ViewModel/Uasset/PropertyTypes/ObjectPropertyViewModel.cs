using GalaSoft.MvvmLight;

namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    public class ObjectPropertyViewModel : UassetPropertyViewModel
    {
        new public const string PROPERTY_NAME = "ObjectProperty";

        private int _Id;
        public  int  Id { get => _Id; set => Set(ref _Id, value); }

        private string _Name;
        public  string  Name { get => _Name; set => Set(ref _Name, value); }


        public ObjectPropertyViewModel(string attrName, UassetLib.ObjectProperty prop) : base(propName: PROPERTY_NAME, attrName: attrName)
        {
            Address = (int)prop.Address;

            Id = prop.Id;
            Name = prop.Name;
        }
    }
}