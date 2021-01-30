namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    internal class BoolPropertyViewModel : UassetPropertyViewModel
    {
        new public const string PROPERTY_NAME = "BoolProperty";

        private bool _Value;
        public  bool  Value { get => _Value; set => Set(ref _Value, value); }


        public BoolPropertyViewModel(string attrName, UassetLib.BoolProperty prop) : base(attrName: attrName, propName: PROPERTY_NAME)
        {
            Value = prop.Value;
        }
    }
}