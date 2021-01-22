using GalaSoft.MvvmLight;
using UassetLib;

namespace UassetReaderWithGui.ViewModel.Uasset.PropertyTypes
{
    /// <summary>
    /// Represents a <see cref="UassetProperty"/>.
    /// </summary>
    public class UassetPropertyViewModel : ViewModelBase
    {
        public const string PROPERTY_NAME = "Property Name";

        private string _PropertyName;
        public  string  PropertyName { get => _PropertyName; set => Set(ref _PropertyName, value); }

        private string _AttributeName = "<Attribute Name>";
        public  string  AttributeName { get => _AttributeName; set => Set(ref _AttributeName, value); }


        public UassetPropertyViewModel()
        {
            PropertyName = PROPERTY_NAME;
        }

        public UassetPropertyViewModel(string attrName) : this()
        {
            AttributeName = attrName;
        }

        public UassetPropertyViewModel(string attrName, string propName) : this(attrName)
        {
            PropertyName = propName;
        }
    }
}