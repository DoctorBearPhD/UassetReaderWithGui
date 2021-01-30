namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    public class FloatPropertyViewModel : UassetPropertyViewModel
    {
        new public const string PROPERTY_NAME = "FloatProperty";

        private float _Value;
        public  float  Value { get => _Value; set => Set(ref _Value, value); }

        public FloatPropertyViewModel(string attrName, UassetLib.FloatProperty prop) : base(attrName: attrName, propName: PROPERTY_NAME)
        {
            Value = prop.Value;
        }
    }
}
