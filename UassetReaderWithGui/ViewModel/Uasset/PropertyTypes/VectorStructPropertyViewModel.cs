using UassetLib;

namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    public class VectorStructPropertyViewModel : UassetPropertyViewModel
    {
        new public const string PROPERTY_NAME = "Special StructProperty";

        private float _X;
        public  float  X { get => _X; set => Set(ref _X, value); }

        private float _Y;
        public  float  Y { get => _Y; set => Set(ref _Y, value); }

        private float _Z;
        public  float  Z { get => _Z; set => Set(ref _Z, value); }


        public VectorStructPropertyViewModel(string attrName, VectorStructProperty prop) : base(attrName: attrName, propName: PROPERTY_NAME)
        {
            X = prop.X;
            Y = prop.Y;
            Z = prop.Z;
        }
    }
}