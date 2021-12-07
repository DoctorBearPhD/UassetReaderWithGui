using UassetLib;

namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    public class ColorStructPropertyViewModel : UassetPropertyViewModel
    {
        new public const string PROPERTY_NAME = "Special StructProperty";

        private byte _A;
        public  byte  A { get => _A; set => Set(ref _A, value); }

        private float _B;
        public  float  B { get => _B; set => Set(ref _B, value); }

        private float _G;
        public  float  G { get => _G; set => Set(ref _G, value); }

        private float _R;
        public  float  R { get => _R; set => Set(ref _R, value); }


        public ColorStructPropertyViewModel(string attrName, ColorStructProperty prop) : base(attrName: attrName, propName: PROPERTY_NAME)
        {
            Address = (int)prop.Address;

            A = prop.A;
            B = prop.B;
            G = prop.G;
            R = prop.R;
        }
    }
}