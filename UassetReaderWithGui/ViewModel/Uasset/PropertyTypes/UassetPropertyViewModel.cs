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

        // Subclasses should reassign this value!
        private string _PropertyName = PROPERTY_NAME;
        public  string  PropertyName { get => _PropertyName; set => Set(ref _PropertyName, value); }

        private string _AttributeName = "<Attribute Name>";
        public  string  AttributeName { get => _AttributeName; set => Set(ref _AttributeName, value); }

        private int _Address;
        public  int  Address { get => _Address; set => Set(ref _Address, value); }


        public UassetPropertyViewModel() { }

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